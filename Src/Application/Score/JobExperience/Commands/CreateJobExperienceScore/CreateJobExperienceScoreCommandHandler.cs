using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Score.JobExperience.Commands.CreateJobExperienceScore;

public class CreateJobExperienceScoreCommandHandler : IRequestHandler<CreateJobExperienceScoreCommand, Guid>
{
    private readonly IRepository<JobExperienceScore> _repository;

    public CreateJobExperienceScoreCommandHandler(IRepository<JobExperienceScore> repository)
    {
        _repository = repository;
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

        await _repository.AddAsync(jobExperience, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return jobExperience.Id;
    }
}