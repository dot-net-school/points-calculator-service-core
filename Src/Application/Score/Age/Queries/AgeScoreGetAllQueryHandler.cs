using Application.Common.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Score.Age.Queries;

public class AgeScoreGetAllQueryHandler : IRequestHandler<AgeScoreGetAllQuery, List<AgeScoreDto>>
{
    private readonly IRepository<AgeScore> _ageScoreRepository;
    public AgeScoreGetAllQueryHandler(IRepository<AgeScore> ageScoreRepository)
    {
        _ageScoreRepository = ageScoreRepository;
    }
    public async Task<List<AgeScoreDto>> Handle(AgeScoreGetAllQuery request, CancellationToken cancellationToken)
    {
        return _ageScoreRepository.GetAll().Adapt<List<AgeScoreDto>>();
    }
}
