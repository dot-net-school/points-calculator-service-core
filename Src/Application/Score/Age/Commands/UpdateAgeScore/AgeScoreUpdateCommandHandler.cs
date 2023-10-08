using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;
using System.Net;

namespace Application.Score.Age.Commands.UpdateAgeScore;

public class AgeScoreUpdateCommandHandler : IRequestHandler<AgeScoreUpdateCommand, OperationResult<string>>
{
    private readonly IRepository<AgeScore> _ageScoreRepository;
    public AgeScoreUpdateCommandHandler(IRepository<AgeScore> repository)
    {
        _ageScoreRepository = repository;
    }
    public async Task<OperationResult<string>> Handle(AgeScoreUpdateCommand request, CancellationToken cancellationToken)
    {
        var ageScore = await _ageScoreRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (ageScore is null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound, HttpStatusCode.NotFound);
        }
        _ageScoreRepository.Update(ageScore);
        await _ageScoreRepository.SaveChangesAsync(cancellationToken);

        return OperationResult<string>.Succeeded("AgeScore was updated!",Resource.Success, HttpStatusCode.OK);

    }
}
