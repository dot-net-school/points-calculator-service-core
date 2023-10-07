using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.DeleteJobExperienceScore;

public class DeleteJobExperienceScoreCommandHandler : IRequestHandler<DeleteJobExperienceScoreCommand, string>
{
    private readonly IRepository<JobExperienceScore> _jobExperienceScoreRepository;

    public DeleteJobExperienceScoreCommandHandler(IRepository<JobExperienceScore> jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
    }

    public async Task<string> Handle(DeleteJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        JobExperienceScore? jobExperienceScore = await _jobExperienceScoreRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (jobExperienceScore == null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound).Data;
        }

        _jobExperienceScoreRepository.Delete(jobExperienceScore);
        await _jobExperienceScoreRepository.SaveChangesAsync(cancellationToken);

        return OperationResult<string>.Succeeded("200").Data;
    }
}