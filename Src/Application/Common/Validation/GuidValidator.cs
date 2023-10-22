namespace Application.Common.Validation;

public static class GuidValidator
{
    public static bool BeAValidGuid(string? id)
    {
        return Guid.TryParse(id,out _);
    }
}