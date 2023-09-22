using MediatR;

namespace Application.Services.AgeScoreServices.Commands.Update;

public record AgeScoreUpdateCommand(Guid Id, int FromAge, int ToAge, int Score) : IRequest;
