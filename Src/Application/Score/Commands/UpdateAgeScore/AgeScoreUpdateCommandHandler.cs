using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using MediatR;

namespace Application.Score.Commands.UpdateAgeScore;

public class AgeScoreUpdateCommandHandler : IRequestHandler<AgeScoreUpdateCommand, string>
{
    private readonly IApplicationDbContext _context;
    public AgeScoreUpdateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<string> Handle(AgeScoreUpdateCommand request, CancellationToken cancellationToken)
    {
        AgeScore? ageScore = await _context.AgeScores.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (ageScore is null)
        {
            return "Id is invalid!";
        }

        ageScore.Update(request.FromAge, request.ToAge, request.Score);
        _context.AgeScores.Update(ageScore);
        await _context.SaveChangesAsync(cancellationToken);

        return "AgeScore was updated!";
    }
}
