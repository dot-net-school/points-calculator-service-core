using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using MediatR;

namespace Application.Services.AgeScoreServices.Commands.Create;

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
        await _dbContext.AgeScores.AddAsync(ageScore, cancellationToken);
       
        await _dbContext.SaveChangesAsync(cancellationToken);

        return ageScore.Id;
    }
}
