using AntiSpam.Core.Callers;
using AntiSpam.Core.PhoneNumbers;

namespace AntiSpam.Ui.ViewModels.Callers
{
    internal static class Helpers
    {
        internal static CallerViewModelDto MapToDto(this Caller? caller) =>
            new()
            {
                Number = caller?.PhoneNumber?.ToString(),
                Type = caller?.Type.ToString(),
                Note = caller?.Note,
            };

        internal static Caller MapToModel(this CallerViewModelDto caller)
        {
            var phoneNumber = PhoneNumber.Parse(caller.Number);
            return new(phoneNumber, caller.Type.MapToModel(), caller.Note);
        }

        private static CallListType MapToModel(this string? type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(CallListType), "CallListType can not be null.");
            }
            return Enum.Parse<CallListType>(type);
        }
    }
}
