using AntiSpam.Core.PhoneNumbers;

namespace AntiSpam.Core.Callers
{
    public class Caller
    {
        public Caller(
            PhoneNumber phoneNumber,
            CallListType type,
            string? note)
        {
            PhoneNumber = phoneNumber;
            Type = type;
            Note = note;
        }

        public PhoneNumber PhoneNumber { get; }

        public CallListType Type { get; }

        public string? Note { get; }

        public override string ToString() =>
            $"{PhoneNumber} {Type}";
    }

    [Flags]
    public enum CallListType : int
    {
        WhiteList = 1,
        BlackList = 2,
    }
}