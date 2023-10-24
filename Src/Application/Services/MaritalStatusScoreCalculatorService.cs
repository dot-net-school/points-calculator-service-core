using Application.Common.Interfaces;

namespace Application.Services;

    public class MaritalStatusScoreCalculatorService : IScoreCalculatorService<int,int>
    {
        public Task<int> CalculateScore(int input,CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

