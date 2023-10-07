using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Score.Age.Commands.CreateAgeScore;

public class AgeScoreCreateCommandHandler : IRequestHandler<AgeScoreCreateCommand, Guid>
{
    private readonly IRepository<AgeScore> _ageScoreRepository;
    public AgeScoreCreateCommandHandler(IRepository<AgeScore> ageScoreRepository)
    {
        _ageScoreRepository = ageScoreRepository;
    }
    public async Task<Guid> Handle(AgeScoreCreateCommand request, CancellationToken cancellationToken)
    {
        AgeScore ageScore = new(request.FromAge, request.ToAge, request.Score);
        await _ageScoreRepository.AddAsync(ageScore, cancellationToken);
        await _ageScoreRepository.SaveChangesAsync(cancellationToken);

        return ageScore.Id;
    }
}
