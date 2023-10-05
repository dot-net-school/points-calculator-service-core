using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.DeleteJobExperienceScore;

public class DeleteJobExperienceScoreCommandHandler : IRequestHandler<DeleteJobExperienceScoreCommand, string>
{
    private readonly IRepository<JobExperienceScore> _repository;

    public DeleteJobExperienceScoreCommandHandler(IRepository<JobExperienceScore> repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(DeleteJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        JobExperienceScore? jobExperienceScore = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (jobExperienceScore == null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound).Data;
        }

        _repository.Delete(jobExperienceScore);
        await _repository.SaveChangesAsync(cancellationToken);

        return OperationResult<string>.Succeeded("200").Data;
    }
}