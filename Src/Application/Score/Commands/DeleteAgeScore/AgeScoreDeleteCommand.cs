using MediatR;

namespace Application.Score.Commands.DeleteAgeScore;

public record AgeScoreDeleteCommand(Guid Id) : IRequest<string>;
