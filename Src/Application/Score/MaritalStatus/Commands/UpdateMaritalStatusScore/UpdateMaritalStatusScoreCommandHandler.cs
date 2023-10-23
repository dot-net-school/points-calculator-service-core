using System.Net;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Score.MaritalStatus.Commands.UpdateMaritalStatusScore;

public class UpdateMaritalStatusScoreCommandHandler : IRequestHandler<UpdateMaritalStatusScoreCommand, OperationResult<string>>
{
    private readonly IRepository<MaritalStatusScore> _maritalStatusScoreRepository;

    public UpdateMaritalStatusScoreCommandHandler(IRepository<MaritalStatusScore> maritalStatusScoreRepository)
    {
        _maritalStatusScoreRepository = maritalStatusScoreRepository;
    }

    public async Task<OperationResult<string>> Handle(UpdateMaritalStatusScoreCommand request, CancellationToken cancellationToken)
    {
        var maritalStatus = await _maritalStatusScoreRepository
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (maritalStatus is null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound);
        }

        maritalStatus.Update(request.Score);
        _maritalStatusScoreRepository.Update(maritalStatus);

        await _maritalStatusScoreRepository.SaveChangesAsync(cancellationToken);

        var isRecordUpdated = await _maritalStatusScoreRepository
            .AnyAsync(x => x.Score != maritalStatus.Score, cancellationToken);

        if (isRecordUpdated)
        {
            return OperationResult<string>.Succeeded((HttpStatusCode.Created).ToString());
        }
        else
        {
            return OperationResult<string>.Failed(Resource.Fail);

        }
    }

}