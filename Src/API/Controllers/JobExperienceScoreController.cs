using Application.Score.Commands.CreateAgeScore;
using Application.Score.Commands.DeleteAgeScore;
using Application.Score.Commands.JobExperienceScore.CreateJobExperienceScore;
using Application.Score.Commands.JobExperienceScore.DeleteJobExperienceScore;
using Application.Score.Commands.JobExperienceScore.UpdateJobExperienceScore;
using Application.Score.Commands.UpdateAgeScore;
using Application.Score.Queries.GetAllAgeScore;
using Application.Score.Queries.GetJobExperienceScore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobExperienceScoreController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobExperienceScoreController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<List<GetJobExperienceScoreDto>>> GetAll()
    {
        return await _mediator.Send(new GetJobExperienceScoreQuery()); ;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateJobExperienceScoreCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(UpdateJobExperienceScoreCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<string>> Delete(Guid Id)
    {
        return await _mediator.Send(new DeleteJobExperienceScoreCommand(Id));
    }
}