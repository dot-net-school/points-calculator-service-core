using Application.Common.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Score.MaritalStatus.Queries;

public class GetMaritalStatusScoreQueryHandler : IRequestHandler<GetMaritalStatusScoreQuery, IReadOnlyList<GetMaritalStatusScoreDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMaritalStatusScoreQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<GetMaritalStatusScoreDto>> Handle(GetMaritalStatusScoreQuery request, CancellationToken cancellationToken)
    {
        return (await _context.MaritalStatusScores
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken))
                .Adapt<IReadOnlyList<GetMaritalStatusScoreDto>>();
    }
}