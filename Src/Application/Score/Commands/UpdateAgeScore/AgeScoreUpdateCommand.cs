using MediatR;

namespace Application.Score.Commands.UpdateAgeScore;

public record AgeScoreUpdateCommand(Guid Id, int FromAge, int ToAge, int Score) : IRequest;
