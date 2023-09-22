using MediatR;

namespace Application.Services.AgeScoreServices.Commands.Delete;

public record AgeScoreDeleteCommand(Guid Id) : IRequest;
