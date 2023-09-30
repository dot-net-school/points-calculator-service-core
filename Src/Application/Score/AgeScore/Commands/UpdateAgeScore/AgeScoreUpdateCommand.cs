using MediatR;

namespace Application.Score.AgeScore.Commands.UpdateAgeScore;

public record AgeScoreUpdateCommand(Guid Id, int FromAge, int ToAge, int Score) : IRequest<string>;
