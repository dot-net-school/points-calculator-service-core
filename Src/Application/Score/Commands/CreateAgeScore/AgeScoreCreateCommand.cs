using MediatR;

namespace Application.Score.Commands.CreateAgeScore;

public record AgeScoreCreateCommand(int FromAge, int ToAge, int Score) : IRequest<Guid>;
