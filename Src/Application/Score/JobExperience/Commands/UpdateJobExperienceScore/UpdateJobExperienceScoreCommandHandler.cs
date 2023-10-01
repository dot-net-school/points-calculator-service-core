using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Application.Score.JobExperience.Commands.UpdateJobExperienceScore;

public class UpdateJobExperienceScoreCommandHandler : IRequestHandler<UpdateJobExperienceScoreCommand, string>
{
    private readonly IApplicationDbContext _context;

    public UpdateJobExperienceScoreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<string> Handle(UpdateJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        var jobExperienceScore = await _context.JobExperienceScores
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (jobExperienceScore == null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound).Data;
        }

        jobExperienceScore.Update(request.MinExperience, request.MaxExperience, request.Score);
        _context.JobExperienceScores.Update(jobExperienceScore);
        await _context.SaveChangesAsync(cancellationToken);

        return OperationResult<string>.Succeeded("200").Data;
    }
}