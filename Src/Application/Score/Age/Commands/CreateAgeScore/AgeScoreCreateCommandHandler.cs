using Application.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.Age.Commands.CreateAgeScore;

public class AgeScoreCreateCommandHandler : IRequestHandler<AgeScoreCreateCommand, OperationResult<int>>
{
    private readonly IAgeScoreRepository _ageScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;

    public AgeScoreCreateCommandHandler(IApplicationUnitOfWork unitOfWork, IAgeScoreRepository ageScoreRepository)
    {
        _ageScoreRepository = ageScoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult<int>> Handle(AgeScoreCreateCommand request, CancellationToken cancellationToken)
    {
        var ageScore = new AgeScore
        {
            Score = request.Score,
            FromAge = request.FromAge,
            ToAge = request.ToAge
        };

        await _ageScoreRepository.AddAsync(ageScore, cancellationToken);

        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}