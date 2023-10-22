using MediatR;
using Shared;

namespace Application.LanguageCertificate.Create;

public record CreateLanguageCertificateCommand(string Name,bool? IsActive)
    :IRequest<OperationResult<int>>;
