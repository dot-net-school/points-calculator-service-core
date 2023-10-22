using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;
using System.Net;
using Application.Common;

namespace Application.Score.Age.Commands.UpdateAgeScore;

public class AgeScoreUpdateCommandHandler : IRequestHandler<AgeScoreUpdateCommand, OperationResult<int>>
{
    private readonly IRepository<AgeScore> _ageScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;

    public AgeScoreUpdateCommandHandler(IApplicationUnitOfWork unitOfWork,IRepository<AgeScore> repository)
    {
        _ageScoreRepository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<OperationResult<int>> Handle(AgeScoreUpdateCommand request, CancellationToken cancellationToken)
    {
        var ageScore = await _ageScoreRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (ageScore is null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound, HttpStatusCode.NotFound);
        }
        _ageScoreRepository.Update(ageScore);
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}
