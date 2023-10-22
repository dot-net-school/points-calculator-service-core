using MediatR;
using Shared;

namespace Application.Score.Age.Commands.CreateAgeScore;

public record AgeScoreCreateCommand(int FromAge, int ToAge, int Score) : IRequest<OperationResult<int>>;