using Android.App;
using Android.Telecom;
using AntiSpam.Applications.PhoneNumberCheckers;
using AntiSpam.Core.Exceptions;
using AntiSpam.Core.PhoneNumbers;
using AntiSpam.Ui.Helpers;
using AntiSpam.Ui.Platforms.Android.Devices.DeviceHelpers;
using AntiSpam.Ui.Platforms.Android.Services.Helpers;

namespace AntiSpam.Ui.Platforms.Android.Services;

[Service(Exported = true, Permission = "android.permission.BIND_SCREENING_SERVICE")]
[IntentFilter(new[] { ServiceInterface })]
public class CallService : CallScreeningService
{
    private readonly IPhoneNumberChecker _phoneNumberChecker;

    public CallService()
    {
        _phoneNumberChecker = PlatformServiceHelper.GetService<IPhoneNumberChecker>()
            ?? throw new PlatformExeption(
                "Dependency injection is failed. IPhoneNumberChecker not be null.");
    }

    public override void OnScreenCall(Call.Details callDetails)
    {
        var phoneNumberString =
            callDetails
                .GetHandle()
                ?.SchemeSpecificPart
                ?? "Unknown number";
        var phoneNumber = PhoneNumber.Parse(phoneNumberString);

        NotificationHelpers.SendNotification(phoneNumber.ToString());

        var isSpam = _phoneNumberChecker.IsSpamNumber(phoneNumber);
        if (isSpam)
        {
            this.RejectIncomingCall(callDetails);
        }
        else
        {
            var response = new CallResponse.Builder().Build()
                ?? throw new PlatformExeption(
                    "Dependency injection is failed. CallResponse not be null.");
            RespondToCall(callDetails, response);
        }
    }
}
