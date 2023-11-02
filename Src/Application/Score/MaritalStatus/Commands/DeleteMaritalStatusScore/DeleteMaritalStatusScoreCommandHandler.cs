using Application.Common;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.MaritalStatus.Commands.DeleteMaritalStatusScore;

public class DeleteMaritalStatusScoreCommandHandler : IRequestHandler<DeleteMaritalStatusScoreCommand, OperationResult<int>>
{
    private readonly IMaritalStatusScoreRepository _maritalStatusScoreRepository;
    private readonly IUnitOfWOrk _unitOfWork;
    public DeleteMaritalStatusScoreCommandHandler(IMaritalStatusScoreRepository maritalStatusScoreRepository, IUnitOfWOrk unitOfWork)
    {
        _maritalStatusScoreRepository = maritalStatusScoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult<int>> Handle(DeleteMaritalStatusScoreCommand request, CancellationToken cancellationToken)
    {
        var maritalStatus = await _maritalStatusScoreRepository.GetByIdAsync(request.Id, cancellationToken);

        if (maritalStatus is null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound);
        }

        _maritalStatusScoreRepository.Remove(maritalStatus);

        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}