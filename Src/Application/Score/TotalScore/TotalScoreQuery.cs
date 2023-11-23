using Application.DTOs.MainScore;
using MediatR;
using Shared;

namespace Application.Score.TotalScore;

public record TotalScoreQuery(string? Id):IRequest<OperationResult<CalculatedMainScoreDto>>;