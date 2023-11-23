using API.Filters;
using Application.Score.UniversityDegree.Command.Create;
using Application.Score.UniversityDegree.Command.Delete;
using Application.Score.UniversityDegree.Command.Update;
using Application.Score.UniversityDegree.Queries;
using Application.Score.UniversityDegree.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModelState]
public class UniversityDegreeController : ControllerBase
{
    private readonly IMediator _mediator;

    public UniversityDegreeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<OperationResult<List<GetUniversityDegreeDto>>> GetAll()
    {
        return await _mediator.Send(new GetListUniversityDegreeQuery());
    }

    [HttpGet("id")]
    public async Task<OperationResult<GetUniversityDegreeDto>> GetById([FromQuery] GetSingleUniversityDegreeQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpPost]
    public async Task<OperationResult<int>> Create(CreateUniversityDegreeCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<OperationResult<int>> Update(UpdateUniversityDegreeCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete]
    public async Task<OperationResult<int>> Delete(DeleteUniversityDegreeCommand command)
    {
        return await _mediator.Send(command);
    }
}