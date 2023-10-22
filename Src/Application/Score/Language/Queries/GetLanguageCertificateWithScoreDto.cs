
using Application.DTOs;

namespace Application.Score.Language.Queries;

public record GetLanguageCertificateWithScoreDto(Guid Id,string Name,bool? IsActive,List<LanguageScoreDto> ScoreDtos);
