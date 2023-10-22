using Application.Common;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.DeleteJobExperienceScore;

public class DeleteJobExperienceScoreCommandHandler : IRequestHandler<DeleteJobExperienceScoreCommand, OperationResult<int>>
{
    private readonly IRepository<JobExperienceScore> _jobExperienceScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;
    public DeleteJobExperienceScoreCommandHandler(IApplicationUnitOfWork unitOfWork
        ,IRepository<JobExperienceScore> jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult<int>> Handle(DeleteJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        JobExperienceScore? jobExperienceScore = await _jobExperienceScoreRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (jobExperienceScore == null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound);
        }

        _jobExperienceScoreRepository.Delete(jobExperienceScore);
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}