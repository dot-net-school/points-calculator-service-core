using System.Net;
using Application.Common;
using Domain.Entities.LanguageScore;
using Domain.Repositories;
using Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using Shared;

namespace Application.Score.Language.Commands.Create;

public class CreateLanguageCertificateScoreCommandHandler
    : IRequestHandler<CreateLanguageCertificateScoreCommand, OperationResult<int>>
{
    private readonly ILanguageScoreRepository _languageScoreRepository;
    private readonly ILanguageCertificateRepository _languageCertificateRepository;
    private readonly IDomainLayerSettings _domainLayerSettings;
    private readonly IApplicationUnitOfWork _unitOfWOrk;

    public CreateLanguageCertificateScoreCommandHandler(IApplicationUnitOfWork unitOfWOrk
        , ILanguageScoreRepository languageScoreRepository,
        ILanguageCertificateRepository languageCertificateRepository,
        IDomainLayerSettings domainLayerSettings)
    {
        _unitOfWOrk = unitOfWOrk;
        _languageScoreRepository = languageScoreRepository;
        _languageCertificateRepository = languageCertificateRepository;
        _domainLayerSettings = domainLayerSettings;
    }

    public async Task<OperationResult<int>> Handle(CreateLanguageCertificateScoreCommand request,
        CancellationToken cancellationToken = default)
    {
        var languageCertification =
            await GetLanguageCertification(Guid.Parse(request.LanguageCertificationId), cancellationToken);

        if (languageCertification is null)
        {
            //TODO Magic Word
            return OperationResult<int>.Failed("languageCertification " + Resource.RecordNotFound,
                HttpStatusCode.NotFound);
        }

        var languageScore = ToEntity(request);
        await AddLanguageScoreAsync(languageScore, cancellationToken);
        return await _unitOfWOrk.SaveAsyncAndReturnResult(cancellationToken);
    }

    private async Task<LanguageCertification?> GetLanguageCertification(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _languageCertificateRepository.GetByIdAsync(id, cancellationToken);
    }

    private LanguageCertificationScore ToEntity(CreateLanguageCertificateScoreCommand request)
    {
        var score = new Domain.ValueObjects.Score(request.Score, _domainLayerSettings);
        return new LanguageCertificationScore(score, request.Mark, Guid.Parse(request.LanguageCertificationId),
            request.IsActive.GetValueOrDefault());
    }

    private async Task AddLanguageScoreAsync(LanguageCertificationScore languageScore,
        CancellationToken cancellationToken = default)
    {
        await _languageScoreRepository.AddAsync(languageScore, cancellationToken);
    }
}