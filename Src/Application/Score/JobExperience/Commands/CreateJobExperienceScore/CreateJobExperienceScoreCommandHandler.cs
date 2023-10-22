using Application.Common;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Score.JobExperience.Commands.CreateJobExperienceScore;

public class CreateJobExperienceScoreCommandHandler : IRequestHandler<CreateJobExperienceScoreCommand, OperationResult<int>>
{
    private readonly IRepository<JobExperienceScore> _jobExperienceScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;


    public CreateJobExperienceScoreCommandHandler(IApplicationUnitOfWork unitOfWork,IRepository<JobExperienceScore> jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
        _unitOfWork = unitOfWork;
        // _context = context;
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