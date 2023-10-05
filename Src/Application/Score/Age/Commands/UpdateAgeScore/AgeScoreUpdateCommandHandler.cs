using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;
using System.Net;

namespace Application.Score.Age.Commands.UpdateAgeScore;

public class AgeScoreUpdateCommandHandler : IRequestHandler<AgeScoreUpdateCommand, OperationResult<string>>
{
    private readonly IApplicationDbContext _context;
    public AgeScoreUpdateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<OperationResult<string>> Handle(AgeScoreUpdateCommand request, CancellationToken cancellationToken)
    {
        var ageScore = await _context.AgeScores.FindAsync(request.Id,cancellationToken);

        if (ageScore is null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound, HttpStatusCode.NotFound);
        }
        ageScore.Update(request.FromAge, request.ToAge, request.Score);
        _context.AgeScores.Update(ageScore);
        await _context.SaveChangesAsync(cancellationToken);
        return OperationResult<string>.Succeeded("AgeScore was updated!",Resource.Success, HttpStatusCode.OK);
    }
}
