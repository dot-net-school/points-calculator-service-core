using Application.Common;
using Domain.Entities.LanguageScore;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.LanguageCertificate.Create;

public class CreateLanguageCertificateCommandHandler:IRequestHandler<CreateLanguageCertificateCommand,OperationResult<int>>
{
    private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly ILanguageCertificateRepository _languageCertificateRepository;

    public CreateLanguageCertificateCommandHandler( IApplicationUnitOfWork unitOfWork, ILanguageCertificateRepository languageCertificateRepository)
    {
        _unitOfWork = unitOfWork;
        _languageCertificateRepository = languageCertificateRepository;
    }

    public async Task<OperationResult<int>> Handle(CreateLanguageCertificateCommand request,
        CancellationToken cancellationToken=default)
    {
        LanguageCertification languageCertification = new LanguageCertification(request.Name, request.IsActive.GetValueOrDefault());
        await _languageCertificateRepository.AddAsync(languageCertification, cancellationToken);
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}