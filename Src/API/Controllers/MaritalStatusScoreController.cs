using API.Filters;
using Application.Score.MaritalStatus.Commands.CreateMaritalStatusScore;
using Application.Score.MaritalStatus.Commands.DeleteMaritalStatusScore;
using Application.Score.MaritalStatus.Commands.UpdateMaritalStatusScore;
using Application.Score.MaritalStatus.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModelState]
public class MaritalStatusScoreController
{
    private readonly IMediator _mediator;

    public MaritalStatusScoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IReadOnlyList<GetMaritalStatusScoreDto>> GetAll()
    {
        return await _mediator.Send(new GetMaritalStatusScoreQuery());
    }

    [HttpPost]
    public async Task<OperationResult<int>> Create(CreateMaritalStatusScoreCommand command)
    {
        return await _mediator.Send(command);
        
    }

    [HttpPut]
    public async Task<ActionResult<OperationResult<int>>> Update(UpdateMaritalStatusScoreCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<OperationResult<int>>> Delete(Guid Id)
    {
        return await _mediator.Send(new DeleteMaritalStatusScoreCommand(Id));
    }
}