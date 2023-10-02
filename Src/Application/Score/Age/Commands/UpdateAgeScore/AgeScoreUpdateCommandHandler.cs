using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;
using System.Net;

namespace Application.Score.Age.Commands.UpdateAgeScore;

public class AgeScoreUpdateCommandHandler : IRequestHandler<AgeScoreUpdateCommand, OperationResult<string>>
{
    private readonly IRepository<AgeScore> _repository;
    public AgeScoreUpdateCommandHandler(IRepository<AgeScore> repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult<string>> Handle(AgeScoreUpdateCommand request, CancellationToken cancellationToken)
    {
        var ageScore = await _repository.GetByIdAsync(request.Id);

        if (ageScore is null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound, (int)HttpStatusCode.Created);
        }

        ageScore.Update(request.FromAge, request.ToAge, request.Score);

        _repository.Update(ageScore);
        await _repository.SaveChangesAsync();

        return OperationResult<string>.Failed("AgeScore was updated!", (int)HttpStatusCode.Created);

    }
}
