using MediatR;

namespace Application.Score.AgeScore.Commands.CreateAgeScore;

public record AgeScoreCreateCommand(int FromAge, int ToAge, int Score) : IRequest<Guid>;
