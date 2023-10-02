using Application.Common.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Score.Age.Queries;

public class AgeScoreGetAllQueryHandler : IRequestHandler<AgeScoreGetAllQuery, List<AgeScoreDto>>
{
    private readonly IRepository<AgeScore> _repository;
    public AgeScoreGetAllQueryHandler(IRepository<AgeScore> repository)
    {
        _repository = repository;
    }
    public async Task<List<AgeScoreDto>> Handle(AgeScoreGetAllQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAll().Adapt<List<AgeScoreDto>>();
    }
}
