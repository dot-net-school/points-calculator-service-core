using Domain.Entities.AgeScoreEntity;
using MediatR;

namespace Application.Services.AgeScoreServices.Queries.GetAll;

public record AgeScoreGetAllQuery() : IRequest<List<AgeScore>>;
