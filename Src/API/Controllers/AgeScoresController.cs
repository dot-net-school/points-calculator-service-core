using Application.Services.AgeScoreServices.Commands.Create;
using Application.Services.AgeScoreServices.Commands.Delete;
using Application.Services.AgeScoreServices.Commands.Update;
using Application.Services.AgeScoreServices.Queries.GetAll;
using Domain.Entities.AgeScoreEntity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgeScoresController : ControllerBase
{
    private readonly IMediator _mediator;
    public AgeScoresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<AgeScore> ageScores = await _mediator.Send(new AgeScoreGetAllQuery());
        return Ok(ageScores);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AgeScoreCreateCommand command)
    {
        Guid Id = await _mediator.Send(command);
        return Ok(Id);
    }

    [HttpPut]
    public async Task<IActionResult> Update(AgeScoreUpdateCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _mediator.Send(new AgeScoreDeleteCommand(Id));
        return Ok();
    }
}
