using Application.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.DeleteJobExperienceScore;

public class DeleteJobExperienceScoreCommandHandler : IRequestHandler<DeleteJobExperienceScoreCommand, OperationResult<int>>
{
    private readonly IJobExperienceScoreRepository _jobExperienceScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;
    public DeleteJobExperienceScoreCommandHandler(IApplicationUnitOfWork unitOfWork
        , IJobExperienceScoreRepository jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult<int>> Handle(DeleteJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        JobExperienceScore? jobExperienceScore = await _jobExperienceScoreRepository.GetByIdAsync(request.Id, cancellationToken);

        if (jobExperienceScore is null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound);
        }

        _jobExperienceScoreRepository.Remove(jobExperienceScore);
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}