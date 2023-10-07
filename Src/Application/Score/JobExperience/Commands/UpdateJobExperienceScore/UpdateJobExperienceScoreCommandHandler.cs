using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.UpdateJobExperienceScore;

public class UpdateJobExperienceScoreCommandHandler : IRequestHandler<UpdateJobExperienceScoreCommand, string>
{
    private readonly IRepository<JobExperienceScore> _jobExperienceScoreRepository;

    public UpdateJobExperienceScoreCommandHandler(IRepository<JobExperienceScore> jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
    }
    public async Task<string> Handle(UpdateJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        var jobExperienceScore = await _jobExperienceScoreRepository
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (jobExperienceScore == null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound).Data;
        }

        jobExperienceScore.Update(request.MinExperience, request.MaxExperience, request.Score);
        _jobExperienceScoreRepository.Update(jobExperienceScore);
        await _jobExperienceScoreRepository.SaveChangesAsync(cancellationToken);

        return OperationResult<string>.Succeeded("200").Data;
    }
}