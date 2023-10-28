using Application.Common;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.UpdateJobExperienceScore;

public class UpdateJobExperienceScoreCommandHandler : IRequestHandler<UpdateJobExperienceScoreCommand, OperationResult<int>>
{
    private readonly IJobExperienceScoreRepository _jobExperienceScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;

    public UpdateJobExperienceScoreCommandHandler(IApplicationUnitOfWork unitOfWork
        , IJobExperienceScoreRepository jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<OperationResult<int>> Handle(UpdateJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        var jobExperienceScore = await _jobExperienceScoreRepository.GetByIdAsync(request.Id, cancellationToken);

        if (jobExperienceScore == null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound);
        }

        jobExperienceScore.Update(request.MinExperience, request.MaxExperience, request.Score);
        _jobExperienceScoreRepository.Update(jobExperienceScore);

        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}