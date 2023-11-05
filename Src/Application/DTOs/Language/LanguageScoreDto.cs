namespace Application.DTOs.Language;

public record LanguageScoreDto(Guid Id,byte Score, string? Mark,bool? IsActive);