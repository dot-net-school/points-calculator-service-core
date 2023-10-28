using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Score.MaritalStatus.Queries;

public class GetMaritalStatusScoreQueryHandler : IRequestHandler<GetMaritalStatusScoreQuery, IReadOnlyList<GetMaritalStatusScoreDto>>
{
    private readonly IMaritalStatusScoreRepository _maritalStatusScoreRepository;

    public GetMaritalStatusScoreQueryHandler(IMaritalStatusScoreRepository maritalStatusScoreRepository)
    {
        _maritalStatusScoreRepository = maritalStatusScoreRepository;
    }

    public async Task<IReadOnlyList<GetMaritalStatusScoreDto>> Handle(GetMaritalStatusScoreQuery request, CancellationToken cancellationToken)
    {
        var maritalStatusScores = await _maritalStatusScoreRepository.GetAllAsync();

        return maritalStatusScores.Adapt<IReadOnlyList<GetMaritalStatusScoreDto>>(); 
    }
}