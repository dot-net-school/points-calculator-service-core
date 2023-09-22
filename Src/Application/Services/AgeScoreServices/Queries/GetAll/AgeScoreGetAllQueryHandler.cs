using Application.Common.Interfaces;
using Domain.Entities.AgeScoreEntity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AgeScoreServices.Queries.GetAll;

public class AgeScoreGetAllQueryHandler : IRequestHandler<AgeScoreGetAllQuery, List<AgeScore>>
{
    private readonly IApplicationDbContext _context;
    public AgeScoreGetAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<AgeScore>> Handle(AgeScoreGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _context.AgeScores.ToListAsync(cancellationToken: cancellationToken);
    }
}
