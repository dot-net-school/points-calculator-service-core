using Application.Common.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Score.MaritalStatus.Queries;

public class GetMaritalStatusScoreQueryHandler : IRequestHandler<GetMaritalStatusScoreQuery, IReadOnlyList<GetMaritalStatusScoreDto>>
{
    private readonly IRepository<MaritalStatusScore> _maritalStatusScoreRepository;

    public GetMaritalStatusScoreQueryHandler(IRepository<MaritalStatusScore> maritalStatusScoreRepository)
    {
        _maritalStatusScoreRepository = maritalStatusScoreRepository;
    }

    public async Task<IReadOnlyList<GetMaritalStatusScoreDto>> Handle(GetMaritalStatusScoreQuery request, CancellationToken cancellationToken)
    {
        var maritalStatusScores = await _maritalStatusScoreRepository.GetAll()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return maritalStatusScores.Adapt<IReadOnlyList<GetMaritalStatusScoreDto>>(); 
    }
}