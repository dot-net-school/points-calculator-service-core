using Application.Common;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.MaritalStatus.Commands.UpdateMaritalStatusScore;

public class UpdateMaritalStatusScoreCommandHandler : IRequestHandler<UpdateMaritalStatusScoreCommand, OperationResult<int>>
{
    private readonly IMaritalStatusScoreRepository _maritalStatusScoreRepository;
    private readonly IUnitOfWOrk _unitOfWork;
    public UpdateMaritalStatusScoreCommandHandler(IMaritalStatusScoreRepository maritalStatusScoreRepository, IUnitOfWOrk unitOfWork)
    {
        _maritalStatusScoreRepository = maritalStatusScoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult<int>> Handle(UpdateMaritalStatusScoreCommand request, CancellationToken cancellationToken)
    {
        var maritalStatus = await _maritalStatusScoreRepository.GetByIdAsync(request.Id, cancellationToken);

        if (maritalStatus is null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound);
        }

        maritalStatus.Update(request.Score);
        _maritalStatusScoreRepository.Update(maritalStatus);

        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);

    }

}