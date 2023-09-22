using Application.Score.Commands.CreateAgeScore;
using Application.Score.Commands.DeleteAgeScore;
using Application.Score.Commands.UpdateAgeScore;
using Application.Score.Queries.GetAllAgeScore;
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
    public async Task<ActionResult<List<AgeScoreDto>>> GetAll()
    {
        return await _mediator.Send(new AgeScoreGetAllQuery()); ;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(AgeScoreCreateCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(AgeScoreUpdateCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<string>> Delete(Guid Id)
    {
        return await _mediator.Send(new AgeScoreDeleteCommand(Id));
    }
}
