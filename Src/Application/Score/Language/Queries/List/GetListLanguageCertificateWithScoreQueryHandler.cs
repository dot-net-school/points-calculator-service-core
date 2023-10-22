using System.Net;
using Application.Common;
using Application.Common.Mappers;
using Domain.Repositories;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Application.Score.Language.Queries.List;

public class GetListLanguageCertificateWithScoreQueryHandler
    : IRequestHandler<GetListLanguageCertificateWithScoreQuery
        , OperationResult<List<GetLanguageCertificateWithScoreDto>>>
{
    private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly ILanguageCertificateRepository _languageCertificateRepository;

    public GetListLanguageCertificateWithScoreQueryHandler(IApplicationUnitOfWork unitOfWork
        , ILanguageCertificateRepository languageCertificateRepository)
    {
        _unitOfWork = unitOfWork;
        _languageCertificateRepository = languageCertificateRepository;
    }

    public async Task<OperationResult<List<GetLanguageCertificateWithScoreDto>>> Handle(
        GetListLanguageCertificateWithScoreQuery request
        , CancellationToken cancellationToken = default)
    {
        var results = await FetchAndMapData(cancellationToken);
        //TODO Check if you can convert count to any
        if (results.Any())
        {
            return OperationResult<List<GetLanguageCertificateWithScoreDto>>
                .Succeeded(results, Resource.Success, HttpStatusCode.Accepted);
        }

        return OperationResult<List<GetLanguageCertificateWithScoreDto>>.Failed(Resource.NoRecords,
            HttpStatusCode.NoContent);
    }

    private async Task<List<GetLanguageCertificateWithScoreDto>> FetchAndMapData(CancellationToken cancellationToken)
    {
        var languageCertifications = await _languageCertificateRepository.GetAllWithScoreAsync(cancellationToken);

        var mapper = new LanguageScoreDtoMapper();
        var result = new List<GetLanguageCertificateWithScoreDto>();

        foreach (var lc in languageCertifications)
        {
            var scoreDtos = lc.LanguageCertificationScores.Select(mapper.Map).ToList();
            result.Add(new GetLanguageCertificateWithScoreDto(lc.Id, lc.Name, lc.IsActive, scoreDtos));
        }

        return result;
    }
}