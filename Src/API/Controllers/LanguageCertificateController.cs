using API.Filters;
using Application.LanguageCertificate.Create;
using Application.LanguageCertificate.Delete;
using Application.LanguageCertificate.Update;
using Application.Score.Language.Queries;
using Application.Score.Language.Queries.List;
using Application.Score.Language.Queries.Single;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModelState]
public class LanguageCertificateController:ControllerBase
{
    private readonly IMediator _mediator;
    public LanguageCertificateController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<OperationResult<List<GetLanguageCertificateWithScoreDto>>> GetAll()
    {
        return await _mediator.Send(new GetListLanguageCertificateWithScoreQuery());
    }

    [HttpGet("id")]
    public async Task<OperationResult<GetLanguageCertificateWithScoreDto>> GetById([FromQuery] GetSingleLanguageCertificateWithScoreQuery query)
    {
        return await _mediator.Send(query);
    }
    
    [HttpPost]
    public async Task<OperationResult<int>> Create(CreateLanguageCertificateCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<OperationResult<int>> Update(UpdateLanguageCertificateCommand command)
    {
        return await _mediator.Send(command);
    }
    [HttpDelete]
    public async Task<OperationResult<int>> Delete(DeleteLanguageCertificateCommand command)
    {
        return await _mediator.Send(command);
    }
}