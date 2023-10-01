using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Score.Age.Commands.DeleteAgeScore;

public class AgeScoreDeleteCommandHandler : IRequestHandler<AgeScoreDeleteCommand, string>
{
    private readonly IApplicationDbContext _context;
    public AgeScoreDeleteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<string> Handle(AgeScoreDeleteCommand request, CancellationToken cancellationToken)
    {
        AgeScore? ageScore = await _context.AgeScores.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (ageScore is null)
        {
            return "Id is invalid!";
        }

        _context.AgeScores.Remove(ageScore);
        await _context.SaveChangesAsync(cancellationToken);
        return "ageScore was deleted!";
    }
}
