using Application.Common;
using Application.Common.Interfaces;
using Application.DTOs;
using Application.DTOs.CustomerService;
using Application.DTOs.Language;
using Application.DTOs.MainScore;
using Domain.Entities.LanguageScore;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class LanguageScoreCalculator
    : IScoreStrategy
{
    private readonly ILanguageScoreRepository _languageScoreRepository;

    public LanguageScoreCalculator(ILanguageScoreRepository languageScoreRepository)
    {
        _languageScoreRepository = languageScoreRepository;
    }

    public async Task<ScoreDataDto> CalculateScore(ReceivedCustomerInfoDto input,
        CancellationToken cancellationToken = default)
    {
        if (IsEmpty(input))
        {
            return NoRecordResult();
        }

        List<ReceivedLanguageDegreeDto> languageScoreDtoList = input.LanguageDegrees;
        if (!languageScoreDtoList.Any())
        {
            return NoRecordResult();
        }

        var languageScoresWithCertification =
            await _languageScoreRepository.GetAllScoresWithCertification(cancellationToken);
        if (!languageScoresWithCertification.Any())
        {
            return NoRecordResult();
        }

        var languageScoreResult = CalculateLanguageScores(languageScoreDtoList, languageScoresWithCertification);
        return GetHighestScore(languageScoreResult);
    }


    private List<ScoreDataDto> CalculateLanguageScores(List<ReceivedLanguageDegreeDto> receivedLanguageDegreeList,
        IReadOnlyCollection<LanguageCertificationScore> languageScores)
    {
        List<ScoreDataDto> languageScoreResult = new List<ScoreDataDto>();
        foreach (var languageMark in receivedLanguageDegreeList)
        {
            //TODO for pte and cad cert we need to check numbers to because we can have numbers between  so wee need to check mark instead of score id
            var languageCertificationScore = languageScores.FirstOrDefault(ls => ls.Id == Guid.Parse(languageMark.Id));
            if (languageCertificationScore is null) continue;
            var result = new ScoreDataDto(
                $"Score For {languageCertificationScore.LanguageCertification.Name} and {languageCertificationScore.Mark} Mark",
                Score: languageCertificationScore.Score.Value);
            languageScoreResult.Add(result);
        }
        return languageScoreResult;
    }

    private bool IsEmpty(ReceivedCustomerInfoDto input)
    {
        if (input is null)
        {
            return true;
        }
        if (input.LanguageDegrees is null)
        {
            return true;
        }
        
        if (!input.LanguageDegrees.Any())
        {
            return true;
        }
        return false;
    }

    private ScoreDataDto GetHighestScore(
        List<ScoreDataDto> languageScoreResult)
    {
        ScoreDataDto? highestScoreData = languageScoreResult.MaxBy(ls => ls.Score);
        if (highestScoreData != null)
        {
            return highestScoreData;
        }

        return NoRecordResult();
    }

    private ScoreDataDto NoRecordResult()
    {
        ScoreDataDto scoreDataDto = new ScoreDataDto("No Record Found For LanguageDegrees", 0);
        return scoreDataDto;
    }
}