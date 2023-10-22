using System.Net;
using Application.Common;
using Domain.Entities.LanguageScore;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.LanguageCertificate.Update;

public class UpdateLanguageCertificateCommandHandler
    : IRequestHandler<UpdateLanguageCertificateCommand, OperationResult<int>>
{
    private readonly ILanguageCertificateRepository _languageCertificateRepository;

    private readonly IApplicationUnitOfWork _unitOfWork;

    public UpdateLanguageCertificateCommandHandler( IApplicationUnitOfWork unitOfWork
        , ILanguageCertificateRepository languageCertificateRepository)
    {
        _unitOfWork = unitOfWork;
        _languageCertificateRepository = languageCertificateRepository;
    }

    public async Task<OperationResult<int>> Handle(UpdateLanguageCertificateCommand request,
        CancellationToken cancellationToken = default)
    {
        LanguageCertification? languageCertification =
            await _languageCertificateRepository.GetByIdAsync(Guid.Parse(request.Id), cancellationToken);
        if (languageCertification is null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound, HttpStatusCode.NotFound);
        }
        languageCertification.UpdateName(request.Name);
        languageCertification.UpdateActiveness(request.IsActive);
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}