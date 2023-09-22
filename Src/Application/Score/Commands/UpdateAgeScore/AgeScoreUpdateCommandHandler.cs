using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using MediatR;

namespace Application.Score.Commands.UpdateAgeScore;

public class AgeScoreUpdateCommandHandler : IRequestHandler<AgeScoreUpdateCommand>
{
    private readonly IApplicationDbContext _context;
    public AgeScoreUpdateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(AgeScoreUpdateCommand request, CancellationToken cancellationToken)
    {
        AgeScore? ageScore = await _context.AgeScores.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (ageScore == null)
            throw new Exception("Id is not valid");

        ageScore.Update(request.FromAge, request.ToAge, request.Score);
        _context.AgeScores.Update(ageScore);
        await _context.SaveChangesAsync(cancellationToken);


    }
}
