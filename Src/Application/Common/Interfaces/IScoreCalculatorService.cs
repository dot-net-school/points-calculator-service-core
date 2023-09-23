namespace Application.Common.Interfaces;

public interface IScoreCalculatorService<TInput, TOutput>
{
    public Task<TOutput> CalculateScore(TInput input);
}
