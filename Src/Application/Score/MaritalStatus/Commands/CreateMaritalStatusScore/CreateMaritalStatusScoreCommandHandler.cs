using Application.Common;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.MaritalStatus.Commands.CreateMaritalStatusScore;

public class CreateMaritalStatusScoreCommandHandler : IRequestHandler<CreateMaritalStatusScoreCommand, OperationResult<int>>
{
    private readonly IMaritalStatusScoreRepository _maritalStatusScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;

    public CreateMaritalStatusScoreCommandHandler(IMaritalStatusScoreRepository maritalStatusScoreRepository, IApplicationUnitOfWork unitOfWork)
    {
        _maritalStatusScoreRepository = maritalStatusScoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult<int>> Handle(CreateMaritalStatusScoreCommand request, CancellationToken cancellationToken)
    {
        var maritalStatus = new MaritalStatusScore
        {
            MaritalStatus = request.MaritalStatus,
            Score = request.Score
        };

        await _maritalStatusScoreRepository.AddAsync(maritalStatus,cancellationToken);

        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}