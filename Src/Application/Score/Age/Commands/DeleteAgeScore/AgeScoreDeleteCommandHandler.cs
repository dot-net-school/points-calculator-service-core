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
        AgeScore? ageScore = await _repository.GetByIdAsync(request.Id);
        if (ageScore is null)
        {
            return "Id is invalid!";
        }

        _repository.DeleteAsync(ageScore);
        await _repository.SaveChangesAsync();
        return "ageScore was deleted!";
    }
}
