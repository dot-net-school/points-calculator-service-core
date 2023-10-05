using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Score.Age.Commands.CreateAgeScore;

public class AgeScoreCreateCommandHandler : IRequestHandler<AgeScoreCreateCommand, Guid>
{
    private readonly IRepository<AgeScore> _repository;
    public AgeScoreCreateCommandHandler(IRepository<AgeScore> repository)
    {
        _repository = repository;
    }
    public async Task<Guid> Handle(AgeScoreCreateCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.AgeScore ageScore = new(request.FromAge, request.ToAge, request.Score);
        await _repository.AddAsync(ageScore, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return ageScore.Id;
    }
}
