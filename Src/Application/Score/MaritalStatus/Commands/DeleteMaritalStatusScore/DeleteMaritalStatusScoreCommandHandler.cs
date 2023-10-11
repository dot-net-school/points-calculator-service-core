using Application.Common.Interfaces;
using MediatR;
using Shared;
using System.Net;
using Domain.Entities;

namespace Application.Score.MaritalStatus.Commands.DeleteMaritalStatusScore;

public class
    DeleteMaritalStatusScoreCommandHandler : IRequestHandler<DeleteMaritalStatusScoreCommand, OperationResult<string>>
{
    private readonly IRepository<MaritalStatusScore> _maritalStatusScoreRepository;

    public DeleteMaritalStatusScoreCommandHandler(IRepository<MaritalStatusScore> maritalStatusScoreRepository)
    {
        _maritalStatusScoreRepository = maritalStatusScoreRepository;
    }

    public async Task<OperationResult<string>> Handle(DeleteMaritalStatusScoreCommand request, CancellationToken cancellationToken)
    {
        var maritalStatus = await _maritalStatusScoreRepository.FindByIdAsync(request.Id, cancellationToken);

        if (maritalStatus is null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound);
        }

        _maritalStatusScoreRepository.Delete(maritalStatus);


        await _maritalStatusScoreRepository.SaveChangesAsync(cancellationToken);

        var isRecordDeleted = await _maritalStatusScoreRepository.ExistsAsync(request.Id, cancellationToken);

        if (isRecordDeleted)
        {
            return OperationResult<string>.Failed(Resource.Fail);
        }
        else
        {
            return OperationResult<string>.Succeeded(((int)HttpStatusCode.Created).ToString());
        }
    }
}