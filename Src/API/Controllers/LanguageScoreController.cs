using API.Filters;
using Application.LanguageCertificate.Create;
using Application.Score.Language.Commands.Create;
using Application.Score.Language.Commands.Delete;
using Application.Score.Language.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModelState]
public class LanguageScoreController:ControllerBase
{
    private readonly IMediator _mediator;

    public LanguageScoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<OperationResult<int>> Create(CreateLanguageCertificateScoreCommand command)
    {
        return await _mediator.Send(command);
    }
    
    [HttpPut]
    public async Task<OperationResult<int>> Update(UpdateLanguageCertificateScoreCommand command)
    {
        return await _mediator.Send(command);
    }
    
    [HttpDelete]
    public async Task<OperationResult<int>> Delete(DeleteLanguageCertificateScoreCommand command)
    {
        return await _mediator.Send(command);
    }
}