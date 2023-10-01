using MediatR;

namespace Application.Score.Age.Commands.DeleteAgeScore;

public record AgeScoreDeleteCommand(Guid Id) : IRequest<string>;
