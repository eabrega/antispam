using Android.Provider;
using AntiSpam.Core.Callers;

namespace AntiSpam.Ui.Platforms.Android.Devices;

public static class CallLogController
{
    public static IReadOnlyCollection<CallLogItem> GetCalls(ICallersRepository callersRepository)
    {
        var phoneContacts = new List<CallLogItem>();
        string[] projection = {
            CallLog.Calls.Number,
            CallLog.Calls.Date,
            CallLog.Calls.Duration,
            CallLog.Calls.Type,
            CallLog.Calls.CachedName,
            CallLog.Calls.CachedNumberType
        };
        var uri = CallLog.Calls.ContentUri?.BuildUpon()
            ?.AppendQueryParameter("limit", "20")
            ?.Build();
        var querySorter = string.Format("{0} desc", CallLog.Calls.Date);

        using (var phones = MainApplication.Context.ContentResolver?.Query(uri!, projection, null, null, querySorter))
        {
            if (phones != null)
            {
                while (phones.MoveToNext())
                {
                    try
                    {
                        var callNumber = phones.GetString(phones.GetColumnIndex(CallLog.Calls.Number));
                        var callDuration = phones.GetString(phones.GetColumnIndex(CallLog.Calls.Duration));

                        var time = TimeSpan.FromSeconds(int.Parse(callDuration ?? "0"));
                        var extraType = phones.GetString(phones.GetColumnIndex(CallLog.Calls.CachedNumberType));
                        var callDate = phones.GetLong(phones.GetColumnIndex(CallLog.Calls.Date));
                        var callName = phones.GetString(phones.GetColumnIndex(CallLog.Calls.CachedName));
                        int callTypeInt = phones.GetInt(phones.GetColumnIndex(CallLog.Calls.Type));

                        if (callNumber is not null)
                        {
                            var caller = callersRepository.GetCaller(callNumber);
                            phoneContacts.Add(new CallLogItem(callName, callNumber, time, ConvertToDate.ToDateTimeFromEpoch(callDate), (CallType)callTypeInt, caller));
                        }
                    }
                    catch
                    {
                        //something wrong with one contact, may be display name is completely empty, decide what to do
                    }
                }
                phones.Close();
            }
            // if we get here, we can't access the contacts. Consider throwing an exception to display to the user
        }
        return phoneContacts;
    }
}

static class ConvertToDate
{
    static readonly DateTime UnixEpochStart = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);

    public static DateTime ToDateTimeFromEpoch(this long epochTime)
    {
        DateTime result = UnixEpochStart.AddMilliseconds(epochTime);
        return result;
    }
}
