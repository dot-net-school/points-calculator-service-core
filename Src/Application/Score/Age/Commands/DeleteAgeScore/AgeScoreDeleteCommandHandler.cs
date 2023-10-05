using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Score.Age.Commands.DeleteAgeScore;

public class AgeScoreDeleteCommandHandler : IRequestHandler<AgeScoreDeleteCommand, string>
{
    private readonly IRepository<AgeScore> _repository;
    public AgeScoreDeleteCommandHandler(IRepository<AgeScore> repository)
    {
        _repository = repository;
    }
    public async Task<string> Handle(AgeScoreDeleteCommand request, CancellationToken cancellationToken)
    {
        AgeScore? ageScore = await _repository.FindByIdAsync(request.Id, cancellationToken);
        if (ageScore is null)
        {
            return "Id is invalid!";
        }

        _repository.Delete(ageScore);
        await _repository.SaveChangesAsync(cancellationToken);
        return "ageScore was deleted!";
    }
}
