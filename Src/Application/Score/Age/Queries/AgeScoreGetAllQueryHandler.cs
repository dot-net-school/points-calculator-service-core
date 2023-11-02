using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Score.Age.Queries;

public class AgeScoreGetAllQueryHandler : IRequestHandler<AgeScoreGetAllQuery, List<AgeScoreDto>>
{
    private readonly IAgeScoreRepository _ageScoreRepository;
    public AgeScoreGetAllQueryHandler(IAgeScoreRepository ageScoreRepository)
    {
        _ageScoreRepository = ageScoreRepository;
    }
    public async Task<List<AgeScoreDto>> Handle(AgeScoreGetAllQuery request, CancellationToken cancellationToken)
    {
        return _ageScoreRepository.GetAllAsync().Adapt<List<AgeScoreDto>>();
    }
}
