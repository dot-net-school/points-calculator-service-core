using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Score.Age.Commands.DeleteAgeScore;

public class AgeScoreDeleteCommandHandler : IRequestHandler<AgeScoreDeleteCommand, string>
{
    private readonly IRepository<AgeScore> _ageScoreRepository;
    public AgeScoreDeleteCommandHandler(IRepository<AgeScore> ageScoreRepository)
    {
        _ageScoreRepository = ageScoreRepository;
    }
    public async Task<string> Handle(AgeScoreDeleteCommand request, CancellationToken cancellationToken)
    {
        AgeScore? ageScore = await _ageScoreRepository.FindByIdAsync(request.Id, cancellationToken);
        if (ageScore is null)
        {
            return "Id is invalid!";
        }

        _ageScoreRepository.Delete(ageScore);
        await _ageScoreRepository.SaveChangesAsync(cancellationToken);
        return "ageScore was deleted!";
    }
}
