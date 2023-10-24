using System.Net;
using Application.Common;
using Domain.Entities.LanguageScore;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.LanguageCertificate.Delete;

public class DeleteLanguageCertificateCommandHandler 
    : IRequestHandler<DeleteLanguageCertificateCommand,OperationResult<int>>
{
    private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly ILanguageCertificateRepository _languageCertificateRepository;

    public DeleteLanguageCertificateCommandHandler( IApplicationUnitOfWork unitOfWork, ILanguageCertificateRepository languageCertificateRepository)
    {
        _unitOfWork = unitOfWork;
        _languageCertificateRepository = languageCertificateRepository;
    }

    public async Task<OperationResult<int>> Handle(DeleteLanguageCertificateCommand request,
        CancellationToken cancellationToken=default)
    {
        LanguageCertification? languageCertification =await _languageCertificateRepository.GetByIdWithScoreAsync(Guid.Parse(request.Id), cancellationToken);
        if (languageCertification is null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound,HttpStatusCode.NotFound);
        }
        _languageCertificateRepository.Remove(languageCertification);
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}