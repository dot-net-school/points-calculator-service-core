using Application.Common.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Score.Queries.GetAllAgeScore;

public class AgeScoreGetAllQueryHandler : IRequestHandler<AgeScoreGetAllQuery, List<AgeScoreDto>>
{
    private readonly IApplicationDbContext _context;
    public AgeScoreGetAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<AgeScoreDto>> Handle(AgeScoreGetAllQuery request, CancellationToken cancellationToken)
    {
        return (await _context.AgeScores.ToListAsync(cancellationToken: cancellationToken)).Adapt<List<AgeScoreDto>>();
    }
}
