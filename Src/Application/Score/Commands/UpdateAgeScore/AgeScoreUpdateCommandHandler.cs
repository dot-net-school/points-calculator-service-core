using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using MediatR;

namespace Application.Score.Commands.UpdateAgeScore;

public class AgeScoreUpdateCommandHandler : IRequestHandler<AgeScoreUpdateCommand>
{
    private readonly IApplicationDbContext _dbContext;
    public AgeScoreUpdateCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(AgeScoreUpdateCommand request, CancellationToken cancellationToken)
    {
        AgeScore? ageScore = await _dbContext.AgeScores.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (ageScore == null)
            throw new KeyNotFoundException(nameof(ageScore));

        ageScore.Update(request.FromAge, request.ToAge, request.Score);
        _dbContext.AgeScores.Update(ageScore);
        await _dbContext.SaveChangesAsync(cancellationToken);


    }
}
