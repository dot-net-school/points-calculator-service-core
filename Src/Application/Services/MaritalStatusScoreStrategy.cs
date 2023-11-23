using Application.Common.Interfaces;
using Application.DTOs.CustomerService;
using Application.DTOs.MainScore;
using Microsoft.AspNetCore.Components.Forms;

namespace Application.Services;

public class MaritalStatusScoreStrategy : IScoreStrategy
{
    public async Task<ScoreDataDto> CalculateScore(ReceivedCustomerInfoDto input,
        CancellationToken cancellationToken = default)
    {
        if (IsEmpty(input))
        {
            return NoRecordResult();
        }
        //ToDO We need to implement this point calculator
        ReceivedMaritalDto receivedMaritalDto = input.Marital;
        return new ScoreDataDto("Score For Martial Status", 5);
    }

    private bool IsEmpty(ReceivedCustomerInfoDto input)
    {
        if (input is null)
        {
            return true;
        }

        if (input.Marital is null)
        {
            return true;
        }

        return false;
    }

    private ScoreDataDto NoRecordResult()
    {
        ScoreDataDto scoreDataDto = new ScoreDataDto("No Record Found For University UniversityDegrees", 0);
        return scoreDataDto;
    }
}