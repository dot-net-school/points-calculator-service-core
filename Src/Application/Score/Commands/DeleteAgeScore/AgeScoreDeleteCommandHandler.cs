using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using MediatR;

namespace Application.Score.Commands.DeleteAgeScore;

public class AgeScoreDeleteCommandHandler : IRequestHandler<AgeScoreDeleteCommand>
{
    private readonly IApplicationDbContext _context;
    public AgeScoreDeleteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(AgeScoreDeleteCommand request, CancellationToken cancellationToken)
    {
        AgeScore? ageScore = await _context.AgeScores.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (ageScore is null)
            throw new Exception("Id is not valid");

        _context.AgeScores.Remove(ageScore);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
