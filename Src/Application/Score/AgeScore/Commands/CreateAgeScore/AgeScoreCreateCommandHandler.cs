using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Score.AgeScore.Commands.CreateAgeScore;

public class AgeScoreCreateCommandHandler : IRequestHandler<AgeScoreCreateCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    public AgeScoreCreateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(AgeScoreCreateCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.AgeScore ageScore = new(request.FromAge, request.ToAge, request.Score);
        _context.AgeScores.Add(ageScore);

        await _context.SaveChangesAsync(cancellationToken);

        return ageScore.Id;
    }
}
