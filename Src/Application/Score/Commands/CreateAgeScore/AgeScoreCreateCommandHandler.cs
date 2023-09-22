using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using MediatR;

namespace Application.Score.Commands.CreateAgeScore;

public class AgeScoreCreateCommandHandler : IRequestHandler<AgeScoreCreateCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;
    public AgeScoreCreateCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> Handle(AgeScoreCreateCommand request, CancellationToken cancellationToken)
    {
        AgeScore ageScore = new(request.FromAge, request.ToAge, request.Score);
        _dbContext.AgeScores.Add(ageScore);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return ageScore.Id;
    }
}
