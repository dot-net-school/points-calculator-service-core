using System.Net;
using Application.Common.Interfaces;
using Application.DTOs.CustomerService;
using Application.DTOs.Language;
using Application.DTOs.MainScore;
using Application.DTOs.UniversityDegree;
using Shared;

namespace Application.Services;

public sealed class TotalScoreCalculator
{
    private readonly List<IScoreStrategy> _scoreCalculators;

    public TotalScoreCalculator(
        List<IScoreStrategy> scoreCalculators)
    {
        _scoreCalculators = scoreCalculators;
    }

    public async Task<OperationResult<CalculatedMainScoreDto>> Calculate(
        ReceivedCustomerInfoDto? returnedCustomerInfoDto,
        CancellationToken cancellationToken = default)
    {
        var scoreDataDtos = new List<ScoreDataDto>();

        foreach (var scoreCalculator in _scoreCalculators)
        {
            ScoreDataDto scoreData = await scoreCalculator.CalculateScore(returnedCustomerInfoDto, cancellationToken);
            scoreDataDtos.Add(scoreData);
        }
        int totalScore = scoreDataDtos.Sum(s => s.Score);
        var calculatedMainScoreDto = new CalculatedMainScoreDto(totalScore, scoreDataDtos);
        return OperationResult<CalculatedMainScoreDto>.Succeeded(calculatedMainScoreDto, Resource.Success, HttpStatusCode.OK);
    }
}