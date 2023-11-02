using MediatR;
using Shared;

namespace Application.Score.UniversityDegree.Queries;

public record GetSingleUniversityDegreeQuery(string? Id):IRequest<OperationResult<GetUniversityDegreeDto>>;