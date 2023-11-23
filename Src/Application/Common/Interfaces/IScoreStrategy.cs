using Application.DTOs.CustomerService;
using Application.DTOs.MainScore;

namespace Application.Common.Interfaces;

public interface IScoreStrategy
{
    public Task<ScoreDataDto> CalculateScore(ReceivedCustomerInfoDto input,CancellationToken cancellationToken=default);
}
