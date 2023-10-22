using Application.DTOs;
using Domain.Entities.LanguageScore;

namespace Application.Common.Mappers;

public sealed class LanguageScoreDtoMapper
{
    public LanguageScoreDto Map(LanguageCertificationScore languageCertificationScore)
    {
        return new LanguageScoreDto(
            languageCertificationScore.Id,
            languageCertificationScore.Score.Value, // Map the Value property of Score to the Score property of the DTO
            languageCertificationScore.Mark,
            languageCertificationScore.IsActive
        );
    }

    public List<LanguageScoreDto> MapList(List<LanguageCertificationScore> languageCertificationScores)
    {
        return languageCertificationScores.Select(Map).ToList();
    }
}