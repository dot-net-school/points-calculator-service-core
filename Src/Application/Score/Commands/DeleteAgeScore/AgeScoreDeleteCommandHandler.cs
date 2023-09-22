using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using MediatR;

namespace Application.Score.Commands.DeleteAgeScore;

public class AgeScoreDeleteCommandHandler : IRequestHandler<AgeScoreDeleteCommand>
{
    private readonly IApplicationDbContext _dbContext;
    public AgeScoreDeleteCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(AgeScoreDeleteCommand request, CancellationToken cancellationToken)
    {
        AgeScore? ageScore = await _dbContext.AgeScores.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (ageScore is null)
            throw new KeyNotFoundException(nameof(ageScore));

        _dbContext.AgeScores.Remove(ageScore);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
