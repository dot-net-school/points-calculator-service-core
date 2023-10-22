using API.Filters;
using Application.Score.JobExperience.Commands.CreateJobExperienceScore;
using Application.Score.JobExperience.Commands.DeleteJobExperienceScore;
using Application.Score.JobExperience.Commands.UpdateJobExperienceScore;
using Application.Score.JobExperience.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModelState]
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
    public async Task<OperationResult<int>> Create(CreateJobExperienceScoreCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<OperationResult<int>> Update(UpdateJobExperienceScoreCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{Id}")]
    public async Task<OperationResult<int>> Delete(Guid Id)
    {
        return await _mediator.Send(new DeleteJobExperienceScoreCommand(Id));
    }
}