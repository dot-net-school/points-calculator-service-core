using MediatR;
using Shared;

namespace Application.LanguageCertificate.Update;

//TODO is it right to make id string for handle it in fluent validation? because if id not a guid type.model binding will fail and request wont reach fluent validation
public record UpdateLanguageCertificateCommand(string? Id,string? Name,bool? IsActive):IRequest<OperationResult<int>>;