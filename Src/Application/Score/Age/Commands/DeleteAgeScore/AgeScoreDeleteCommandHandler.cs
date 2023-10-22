using System.Net;
using Application.Common;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Score.Age.Commands.DeleteAgeScore;

public class AgeScoreDeleteCommandHandler : IRequestHandler<AgeScoreDeleteCommand, OperationResult<int>>
{
    private readonly IRepository<AgeScore> _ageScoreRepository;
    private readonly IApplicationUnitOfWork _unitOfWork;

   // private readonly IApplicationDbContext _context;
    public AgeScoreDeleteCommandHandler(IRepository<AgeScore> ageScoreRepository,IApplicationUnitOfWork unitOfWork)
    {
        _ageScoreRepository = ageScoreRepository;
        _unitOfWork = unitOfWork;
        //_context = context;
    }
    public async Task<OperationResult<int>> Handle(AgeScoreDeleteCommand request, CancellationToken cancellationToken)
    {
        AgeScore? ageScore = await _ageScoreRepository.FindByIdAsync(request.Id, cancellationToken);
        if (ageScore is null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound,HttpStatusCode.NotFound);
        }

        _ageScoreRepository.Delete(ageScore);
        await _ageScoreRepository.SaveChangesAsync(cancellationToken);
        return await _unitOfWork.SaveAsyncAndReturnResult(cancellationToken);
    }
}
