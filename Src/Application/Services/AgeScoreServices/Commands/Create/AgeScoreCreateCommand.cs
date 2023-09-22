using MediatR;

namespace Application.Services.AgeScoreServices.Commands.Create;

public record AgeScoreCreateCommand(int FromAge, int ToAge, int Score) : IRequest<Guid>;
