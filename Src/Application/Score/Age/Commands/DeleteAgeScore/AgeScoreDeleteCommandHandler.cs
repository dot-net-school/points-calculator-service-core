using Application.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Shared;
using System.Net;

namespace Application.Score.Age.Commands.DeleteAgeScore;

public class AgeScoreDeleteCommandHandler : IRequestHandler<AgeScoreDeleteCommand, OperationResult<int>>
{
    private readonly IAgeScoreRepository _ageScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;

    public AgeScoreDeleteCommandHandler(IAgeScoreRepository ageScoreRepository,IApplicationUnitOfWork unitOfWork)
    {
        _ageScoreRepository = ageScoreRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<OperationResult<int>> Handle(AgeScoreDeleteCommand request, CancellationToken cancellationToken)
    {
        AgeScore? ageScore = await _ageScoreRepository.GetByIdAsync(request.Id, cancellationToken);
        if (ageScore is null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound,HttpStatusCode.NotFound);
        }

        _ageScoreRepository.Remove(ageScore);
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}
