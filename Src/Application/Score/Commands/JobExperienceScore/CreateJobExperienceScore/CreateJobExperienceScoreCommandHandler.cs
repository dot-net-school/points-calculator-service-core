using Application.Common.Interfaces;
using Domain.Entities.JobExperienceScoreEntity;
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
        JobExperienceScore jobExperience = new(request.MinExperience, request.MaxExperience, request.Score);
        _context.JobExperienceScores.Add(jobExperience);

        await _context.SaveChangesAsync(cancellationToken);

        return jobExperience.Id;
    }
}