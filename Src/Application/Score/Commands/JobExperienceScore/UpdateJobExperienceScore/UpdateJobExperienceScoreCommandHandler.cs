using Application.Common.Interfaces;
using Domain.Entities.JobExperienceScoreEntity;
using MediatR;
using Shared.Application;

namespace Application.Score.Commands.JobExperienceScore.UpdateJobExperienceScore;

public class UpdateJobExperienceScoreCommandHandler : IRequestHandler<UpdateJobExperienceScoreCommand,string>
{
    private readonly IApplicationDbContext _context;

    public UpdateJobExperienceScoreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<string> Handle(UpdateJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        JobExperienceScore? jobExperienceScore = await _context.JobExperienceScores.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);

        if (jobExperienceScore == null)
        {
            return OperationResult.Failed(Resource.RecordNotFound);
        }

        jobExperienceScore.Update(request.MinExperience, request.MaxExperience, request.Score);
        _context.JobExperienceScores.Update(jobExperienceScore);
        await _context.SaveChangesAsync(cancellationToken);

        return OperationResult.Succeeded();
    }
}