using API.Filters;
using Application.DTOs.MainScore;
using Application.Score.TotalScore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModelState]
public class TotalScoreController:ControllerBase
{
    private readonly IMediator _mediator;

    public TotalScoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("id")]
    public async Task<OperationResult<CalculatedMainScoreDto>> ReceiveId([FromQuery]  TotalScoreQuery query)
    {
        return await _mediator.Send(query);
    }
}