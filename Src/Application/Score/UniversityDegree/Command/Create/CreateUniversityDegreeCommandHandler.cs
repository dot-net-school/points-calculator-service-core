using Application.Common;
using Domain.Repositories;
using Infrastructure.Settings;
using MediatR;
using Shared;

namespace Application.Score.UniversityDegree.Command.Create;

public sealed class
    CreateUniversityDegreeCommandHandler : IRequestHandler<CreateUniversityDegreeCommand, OperationResult<int>>
{
    private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly IUniversityDegreeRepository _universityDegreeRepository;
    private readonly IDomainLayerSettings _domainLayerSettings;

    public CreateUniversityDegreeCommandHandler(IApplicationUnitOfWork unitOfWork,
        IUniversityDegreeRepository universityDegreeRepository, IDomainLayerSettings domainLayerSettings)
    {
        _unitOfWork = unitOfWork;
        _universityDegreeRepository = universityDegreeRepository;
        _domainLayerSettings = domainLayerSettings;
    }

    public async Task<OperationResult<int>> Handle(CreateUniversityDegreeCommand request,
        CancellationToken cancellationToken = default)
    {
        var universityDegree = ToEntity(request);
        await _universityDegreeRepository.AddAsync(universityDegree, cancellationToken);
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }

    private Domain.Entities.UniversityDegree ToEntity(CreateUniversityDegreeCommand request)
    {
        var score = new Domain.ValueObjects.Score(request.Score, _domainLayerSettings);
        return new Domain.Entities.UniversityDegree(
            score,
            request.UniversityName,
            request.DegreeName,
            request.DegreeLevel.GetValueOrDefault()
            , request.SectionType.GetValueOrDefault(), request.IsActive.GetValueOrDefault());
    }
}