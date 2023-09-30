using Application.Common.Interfaces;
using MediatR;
using Shared.Application;

namespace Application.Score.JobExperienceScore.Commands.DeleteJobExperienceScore;

public class DeleteJobExperienceScoreCommandHandler : IRequestHandler<DeleteJobExperienceScoreCommand, string>
{
    private readonly IApplicationDbContext _context;

    public DeleteJobExperienceScoreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(DeleteJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.JobExperienceScore? jobExperienceScore = await _context.JobExperienceScores.FindAsync(request.Id, cancellationToken);

        if (jobExperienceScore == null)
        {
            return OperationResult.Failed(Resource.RecordNotFound);
        }

        _context.JobExperienceScores.Remove(jobExperienceScore);
        await _context.SaveChangesAsync(cancellationToken);

        return OperationResult.Succeeded();
    }
}