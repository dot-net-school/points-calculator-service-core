using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Score.JobExperience.Commands.CreateJobExperienceScore;

public class CreateJobExperienceScoreCommandHandler : IRequestHandler<CreateJobExperienceScoreCommand, Guid>
{
    private readonly IRepository<JobExperienceScore> _jobExperienceScoreRepository;

    public CreateJobExperienceScoreCommandHandler(IRepository<JobExperienceScore> jobExperienceScoreRepository)
    {
        _jobExperienceScoreRepository = jobExperienceScoreRepository;
    }

    public async Task<Guid> Handle(CreateJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        var jobExperience = new JobExperienceScore
        {
            Id = Guid.NewGuid(),
            MinExperience = request.MinExperience,
            MaxExperience = request.MaxExperience,
            Score = request.Score

        };

        await _jobExperienceScoreRepository.AddAsync(jobExperience, cancellationToken);
        await _jobExperienceScoreRepository.SaveChangesAsync(cancellationToken);

        return jobExperience.Id;
    }
}