using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;
using System.Net;

namespace Application.Score.MaritalStatus.Commands.CreateMaritalStatusScore;

public class CreateMaritalStatusScoreCommandHandler : IRequestHandler<CreateMaritalStatusScoreCommand, OperationResult<Guid>>
{
    private readonly IRepository<MaritalStatusScore> _maritalStatusScoreRepository;

    public CreateMaritalStatusScoreCommandHandler(IRepository<MaritalStatusScore> maritalStatusScoreRepository)
    {
        _maritalStatusScoreRepository = maritalStatusScoreRepository;
    }

    public async Task<OperationResult<Guid>> Handle(CreateMaritalStatusScoreCommand request, CancellationToken cancellationToken)
    {
        var maritalStatus = new MaritalStatusScore
        {
            MaritalStatus = request.MaritalStatus,
            Score = request.Score
        };

        await _maritalStatusScoreRepository.AddAsync(maritalStatus,cancellationToken);

        await _maritalStatusScoreRepository.SaveChangesAsync(cancellationToken);

        var savedRecord = await _maritalStatusScoreRepository.FirstOrDefaultAsync(
            x => x.Id == maritalStatus.Id, cancellationToken);

        if (savedRecord != null)
        {
            return OperationResult<Guid>.Succeeded(maritalStatus.Id, ((int)HttpStatusCode.Created).ToString());
        }
        else
        {
            return OperationResult<Guid>.Failed(Resource.Fail, HttpStatusCode.Created);
        }


    }
}