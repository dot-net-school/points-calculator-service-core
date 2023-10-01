using Application.Common.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Score.JobExperience.Queries;

public class GetJobExperienceScoreQueryHandler : IRequestHandler<GetJobExperienceScoreQuery, List<GetJobExperienceScoreDto>>
{
    private readonly IApplicationDbContext _context;

    public GetJobExperienceScoreQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<GetJobExperienceScoreDto>> Handle(GetJobExperienceScoreQuery request, CancellationToken cancellationToken)
    {
        return (await _context.JobExperienceScores.ToListAsync(cancellationToken: cancellationToken)).Adapt<List<GetJobExperienceScoreDto>>();
    }

}