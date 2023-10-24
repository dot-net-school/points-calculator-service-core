using Application.Common;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.UpdateJobExperienceScore;

public class UpdateJobExperienceScoreCommandHandler : IRequestHandler<UpdateJobExperienceScoreCommand, OperationResult<int>>
{
    private readonly IRepository<JobExperienceScore> _jobExperienceScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;

    public UpdateJobExperienceScoreCommandHandler(IApplicationUnitOfWork unitOfWork
        ,IRepository<JobExperienceScore> jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
        _unitOfWork = unitOfWork;
        //_context = context;
    }
    public async Task<OperationResult<int>> Handle(UpdateJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        var jobExperienceScore = await _jobExperienceScoreRepository
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (jobExperienceScore == null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound);
        }

        jobExperienceScore.Update(request.MinExperience, request.MaxExperience, request.Score);
        _jobExperienceScoreRepository.Update(jobExperienceScore);

        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}