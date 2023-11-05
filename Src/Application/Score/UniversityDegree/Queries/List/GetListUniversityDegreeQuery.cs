using MediatR;
using Shared;

namespace Application.Score.UniversityDegree.Queries.List;

public record GetListUniversityDegreeQuery():IRequest<OperationResult<List<GetUniversityDegreeDto>>>;