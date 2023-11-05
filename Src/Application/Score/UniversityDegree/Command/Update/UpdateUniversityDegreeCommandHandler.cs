using System.Net;
using Application.Common;
using Domain.Repositories;
using Infrastructure.Settings;
using MediatR;
using Shared;

namespace Application.Score.UniversityDegree.Command.Update;

public class UpdateUniversityDegreeCommandHandler:IRequestHandler<UpdateUniversityDegreeCommand,OperationResult<int>>
{
    private readonly IUniversityDegreeRepository _universityDegreeRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly IDomainLayerSettings _domainLayerSettings;

    public UpdateUniversityDegreeCommandHandler(IUniversityDegreeRepository universityDegreeRepository, IApplicationUnitOfWork unitOfWork, IDomainLayerSettings domainLayerSettings)
    {
        _universityDegreeRepository = universityDegreeRepository;
        _unitOfWork = unitOfWork;
        _domainLayerSettings = domainLayerSettings;
    }

    public async Task<OperationResult<int>> Handle(UpdateUniversityDegreeCommand request, CancellationToken cancellationToken=default)
    {
        Domain.Entities.UniversityDegree? universityDegree =
            await _universityDegreeRepository.GetByIdAsyncAsNoTracking(Guid.Parse(request.Id), cancellationToken);

        if (universityDegree is null)
        {
            return OperationResult<int>.Failed(Resource.NoRecords, HttpStatusCode.NotFound);
        }
        var score = new Domain.ValueObjects.Score(request.Score, _domainLayerSettings);
        
        Domain.Entities.UniversityDegree universityDegreeModel = new Domain.Entities.UniversityDegree
        {
            Id = Guid.Parse(request.Id),
            UniversityName = request.UniversityName,
            DegreeName = request.DegreeName,
            DegreeLevel = request.DegreeLevel.GetValueOrDefault(),
            SectionType = request.SectionType.GetValueOrDefault(),
            IsActive = request.IsActive.GetValueOrDefault(),
            Score = score
        };
        _universityDegreeRepository.Update(universityDegreeModel);
         return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}