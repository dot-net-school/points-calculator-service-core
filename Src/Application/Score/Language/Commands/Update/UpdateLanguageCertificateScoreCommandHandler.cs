using System.Net;
using Application.Common;
using Domain.Entities.LanguageScore;
using Domain.Repositories;
using Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using Shared;

namespace Application.Score.Language.Commands.Update;

public class
    UpdateLanguageCertificateScoreCommandHandler : IRequestHandler<UpdateLanguageCertificateScoreCommand,
        OperationResult<int>>
{
    private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly ILanguageScoreRepository _languageScoreRepository;
    private readonly ILanguageCertificateRepository _languageCertificateRepository;
    private readonly IDomainLayerSettings _domainLayerSettings;

    public UpdateLanguageCertificateScoreCommandHandler(IApplicationUnitOfWork unitOfWork,
        ILanguageScoreRepository languageScoreRepository, ILanguageCertificateRepository languageCertificateRepository,
        IDomainLayerSettings domainLayerSettings)
    {
        _languageScoreRepository = languageScoreRepository;
        _languageCertificateRepository = languageCertificateRepository;
        _domainLayerSettings = domainLayerSettings;
        _unitOfWork = unitOfWork;
    }


    public async Task<OperationResult<int>> Handle(UpdateLanguageCertificateScoreCommand request
        , CancellationToken cancellationToken = default)
    {
        var languageCertification = await GetLanguageCertification(Guid.Parse(request.LanguageCertificationId), cancellationToken);

        if (languageCertification is null)
        {
            //TDO Magic Word
            return OperationResult<int>.Failed("languageCertification " + Resource.RecordNotFound,
                HttpStatusCode.NotFound);
        }

        var languageScore = await GetLanguageScore(Guid.Parse(request.Id), cancellationToken);
        if (languageScore is null)
        {
            //TDO Magic Word
            return OperationResult<int>.Failed("languageCertificationScore " + Resource.RecordNotFound,
                HttpStatusCode.NotFound);
        }

        languageScore.UpdateActiveness(request.IsActive);
        languageScore.UpdateMark(request.Mark);
        var score = new Domain.ValueObjects.Score(request.Score, _domainLayerSettings);
        languageScore.UpdateScore(score);
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }

    private async Task<LanguageCertification?> GetLanguageCertification(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _languageCertificateRepository.GetByIdAsNoTrackingAsync(id, cancellationToken);
    }

    private async Task<LanguageCertificationScore?> GetLanguageScore(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _languageScoreRepository.GetByIdAsync(id, cancellationToken);
    }
}