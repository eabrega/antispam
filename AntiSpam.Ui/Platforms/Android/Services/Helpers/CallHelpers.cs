using Android.Telecom;
using AntiSpam.Core.Exceptions;
using static Android.Telecom.CallScreeningService;

namespace AntiSpam.Ui.Platforms.Android.Services.Helpers;

internal static class CallHelpers
{
    internal static void RejectIncomingCall(
        this CallScreeningService callScreeningService,
        Call.Details callDetails)
    {
        var builder = new CallResponse.Builder();
        if (OperatingSystem.IsAndroidVersionAtLeast(29))
        {
            builder?.SetSilenceCall(true);
        }

        builder
            ?.SetRejectCall(true)
            ?.SetDisallowCall(true)
            ?.SetSkipCallLog(true)
            ?.SetSkipNotification(true);

        var response = builder?.Build()
            ?? throw new PlatformExeption(
                "Dependency injection is failed. CallResponse not be null.");

        callScreeningService.RespondToCall(callDetails, response);
    }
}
