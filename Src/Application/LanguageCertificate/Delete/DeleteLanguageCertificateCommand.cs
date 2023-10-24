using MediatR;
using Shared;

namespace Application.LanguageCertificate.Delete;

public record DeleteLanguageCertificateCommand(string? Id):IRequest<OperationResult<int>>;
