using MediatR;

namespace Application.Score.AgeScore.Commands.DeleteAgeScore;

public record AgeScoreDeleteCommand(Guid Id) : IRequest<string>;
