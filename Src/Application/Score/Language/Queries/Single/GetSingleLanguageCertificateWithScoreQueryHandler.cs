using System.Net;
using Application.Common;
using Application.Common.Mappers;
using Domain.Entities.LanguageScore;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.Language.Queries.Single;

public class GetSingleLanguageCertificateWithScoreQueryHandler : IRequestHandler<
    GetSingleLanguageCertificateWithScoreQuery
    , OperationResult<GetLanguageCertificateWithScoreDto>>
{
    private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly ILanguageCertificateRepository _languageScoreRepository;
    
    public GetSingleLanguageCertificateWithScoreQueryHandler(IApplicationUnitOfWork unitOfWork, ILanguageCertificateRepository languageScoreRepository)
    {
        _unitOfWork = unitOfWork;
        _languageScoreRepository = languageScoreRepository;
    }
    //TODO Ask mammad: put all language queries in one request or separate them

    public async Task<OperationResult<GetLanguageCertificateWithScoreDto>> Handle(
        GetSingleLanguageCertificateWithScoreQuery request
        , CancellationToken cancellationToken = default)
    {
        LanguageCertification? languageCertification =
            await _languageScoreRepository.GetByIdAsNoTrackingWithScoreAsync(Guid.Parse(request.Id),cancellationToken);
        if (languageCertification is null)
        {
            return OperationResult<GetLanguageCertificateWithScoreDto>
                .Failed(Resource.RecordNotFound, HttpStatusCode.NotFound);
        }
        
        var mapper = new LanguageScoreDtoMapper();
        var scoreDtos = languageCertification.LanguageCertificationScores.Select(mapper.Map).ToList();

        var result = new GetLanguageCertificateWithScoreDto(
            languageCertification.Id,
            languageCertification.Name,
            languageCertification.IsActive,
            scoreDtos
        );

        return OperationResult<GetLanguageCertificateWithScoreDto>
            .Succeeded(result, Resource.Success, HttpStatusCode.OK);
    }
}