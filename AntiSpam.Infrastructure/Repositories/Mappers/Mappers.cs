using AntiSpam.Core.Callers;
using AntiSpam.Database.Models;

namespace AntiSpam.Infrastructure.Repositories.Mappers;

internal static class Mappers
{
    internal static Caller MapToModel(this CallerDto dto) =>
        new(
            dto.PhoneNumber,
            (CallListType)Enum.Parse(typeof(CallListType), dto.Type),
            dto.Note);

    internal static CallerDto MapToDto(this Caller model) =>
        new()
        {
            PhoneNumber = model.PhoneNumber.ToLong(),
            Type = model.Type.ToString(),
            Note = model?.Note
        };
}
