using Application.Common.Interfaces;
using MediatR;

namespace Application.Score.Commands.JobExperienceScore.CreateJobExperienceScore;

public class CreateJobExperienceScoreCommandHandler : IRequestHandler<CreateJobExperienceScoreCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateJobExperienceScoreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        var jobExperience = new Domain.Entities.JobExperienceScore
        {
            Id = Guid.NewGuid(),
            MinExperience = request.MinExperience,
            MaxExperience = request.MaxExperience,
            Score = request.Score

        };
        _context.JobExperienceScores.Add(jobExperience);

        await _context.SaveChangesAsync(cancellationToken);

        return jobExperience.Id;
    }
}