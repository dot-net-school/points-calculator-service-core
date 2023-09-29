using Application.Common.Interfaces;
using Domain.Entities.JobExperienceScoreEntity;
using MediatR;

namespace Application.Score.Commands.JobExperienceScore.DeleteJobExperienceScore;

public class DeleteJobExperienceScoreCommandHandler : IRequestHandler<DeleteJobExperienceScoreCommand, string>
{
    private readonly IApplicationDbContext _context;

    public DeleteJobExperienceScoreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(DeleteJobExperienceScoreCommand request, CancellationToken cancellationToken)
    {
        JobExperienceScore? jobExperienceScore = await _context.JobExperienceScores.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);

        if (jobExperienceScore == null)
        {
            return "Record Not Found";
        }

        _context.JobExperienceScores.Remove(jobExperienceScore);
        await _context.SaveChangesAsync(cancellationToken);

        return "Record Delete Succeeded";
    }
}