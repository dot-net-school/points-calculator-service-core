using Application.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.CreateJobExperienceScore;

public class CreateJobExperienceScoreCommandHandler : IRequestHandler<CreateJobExperienceScoreCommand, OperationResult<int>>
{
    private readonly IJobExperienceScoreRepository _jobExperienceScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;


    public CreateJobExperienceScoreCommandHandler(IApplicationUnitOfWork unitOfWork, IJobExperienceScoreRepository jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult<int>> Handle(CreateJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        var jobExperience = new JobExperienceScore
        {
            Id = Guid.NewGuid(),
            MinExperience = request.MinExperience,
            MaxExperience = request.MaxExperience,
            Score = request.Score

        };

        await _jobExperienceScoreRepository.AddAsync(jobExperience, cancellationToken);
        
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}