using Application.Common;
using Application.Common.Interfaces;
using Application.DTOs;
using Application.DTOs.Language;
using Domain.Entities.LanguageScore;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class LanguageScoreCalculator
    : IScoreCalculatorService<LanguageMarkDtoList, LanguageMarkDtoList>
{
    private readonly ILanguageScoreRepository _languageScoreRepository;
    
    public LanguageScoreCalculator(ILanguageScoreRepository languageScoreRepository)
    {
        _languageScoreRepository = languageScoreRepository;
    }

    public async Task<LanguageMarkDtoList> CalculateScore(LanguageMarkDtoList languageScoreDtoList,
        CancellationToken cancellationToken = default)
    {
        if (IsEmpty(languageScoreDtoList))
        {
            return NoRecordResult(languageScoreDtoList);
        }
        var languageScoresWithCertification = await _languageScoreRepository.GetAllScoresWithCertification(cancellationToken);
        if (!languageScoresWithCertification.Any())
        {
            return NoRecordResult(languageScoreDtoList);
        }
        var languageScoreResult = CalculateLanguageScores(languageScoreDtoList, languageScoresWithCertification);
        return GetHighestScore(languageScoreDtoList, languageScoreResult);
    }

    private bool IsEmpty(LanguageMarkDtoList languageScoreDtoList)
    {
        return languageScoreDtoList.LanguageScoreDto == null || !languageScoreDtoList.LanguageScoreDto.Any();
    }

    private LanguageMarkDtoList NoRecordResult(LanguageMarkDtoList languageScoreDtoList)
    {
        languageScoreDtoList.LanguageScoreResultDto =
            new LanguageScoreResultDto(LanguageCertificationName: "No Record", Score: 0);
        return languageScoreDtoList;
    }
    private List<LanguageScoreResultDto> CalculateLanguageScores(LanguageMarkDtoList languageScoreDtoList,
        IReadOnlyCollection<LanguageCertificationScore> languageScores)
    {
        List<LanguageScoreResultDto> languageScoreResult = new List<LanguageScoreResultDto>();
        foreach (var languageMark in languageScoreDtoList.LanguageScoreDto)
        {
            var languageCertificationScore = languageScores.FirstOrDefault(ls => ls.Id == languageMark.Id);
            if (languageCertificationScore is null) continue;
            var result = new LanguageScoreResultDto(
                LanguageCertificationName: languageCertificationScore.LanguageCertification.Name,
                Score: languageCertificationScore.Score.Value);
            languageScoreResult.Add(result);
        }
        return languageScoreResult;
    }

    private LanguageMarkDtoList GetHighestScore(LanguageMarkDtoList languageScoreDtoList,
        List<LanguageScoreResultDto> languageScoreResult)
    {
        LanguageScoreResultDto? highestScore = languageScoreResult.MaxBy(ls => ls.Score);
        if (highestScore != null)
        {
            languageScoreDtoList.LanguageScoreResultDto = highestScore;
            return languageScoreDtoList;
        }
        return NoRecordResult(languageScoreDtoList);
    }
}