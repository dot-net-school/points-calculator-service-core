using System.Net;
using Application.Common;
using Domain.Entities.LanguageScore;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.Language.Commands.Delete;

public class
    DeleteLanguageCertificateScoreCommandHandler : IRequestHandler<DeleteLanguageCertificateScoreCommand,
        OperationResult<int>>
{
    private readonly ILanguageScoreRepository _languageScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWOrk;

    public DeleteLanguageCertificateScoreCommandHandler( IApplicationUnitOfWork unitOfWOrk, ILanguageScoreRepository languageScoreRepository)
    {
        _unitOfWOrk = unitOfWOrk;
        _languageScoreRepository = languageScoreRepository;
    }

    public async Task<OperationResult<int>> Handle(DeleteLanguageCertificateScoreCommand request,
        CancellationToken cancellationToken = default)
    {
        LanguageCertificationScore? languageCertificationScore =
            await _languageScoreRepository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
        if (languageCertificationScore is null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound, HttpStatusCode.NotFound);
        }

        _languageScoreRepository.Remove(languageCertificationScore);
        return await _unitOfWOrk.SaveAsyncAndReturnResult(cancellationToken);
    }
}