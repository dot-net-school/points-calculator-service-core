
using Application.DTOs;
using Application.DTOs.Language;

namespace Application.Score.Language.Queries;

public record GetLanguageCertificateWithScoreDto(Guid Id,string Name,bool? IsActive,List<LanguageScoreDto> ScoreDtos);
