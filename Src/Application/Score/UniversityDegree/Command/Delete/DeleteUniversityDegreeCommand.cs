using MediatR;
using Shared;

namespace Application.Score.UniversityDegree.Command.Delete;

public record DeleteUniversityDegreeCommand(string? Id):IRequest<OperationResult<int>>;