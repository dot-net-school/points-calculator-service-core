using System.Net;
using Application.Common;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.UniversityDegree.Command.Delete;

public class DeleteUniversityDegreeCommandHandler:IRequestHandler<DeleteUniversityDegreeCommand,OperationResult<int>>
{
    private readonly IUniversityDegreeRepository _universityDegreeRepository;
    private readonly IApplicationUnitOfWork _unitOfWOrk;

    public DeleteUniversityDegreeCommandHandler(IUniversityDegreeRepository universityDegreeRepository, IApplicationUnitOfWork unitOfWOrk)
    {
        _universityDegreeRepository = universityDegreeRepository;
        _unitOfWOrk = unitOfWOrk;
    }

    public async Task<OperationResult<int>> Handle(DeleteUniversityDegreeCommand request, CancellationToken cancellationToken=default)
    {
        var universityDegree =await _universityDegreeRepository
            .GetByIdAsync(Guid.Parse(request.Id),cancellationToken);
        if (universityDegree is null)
        {
            return OperationResult<int>.Failed(Resource.RecordNotFound, HttpStatusCode.NotFound);
        }
        _universityDegreeRepository.Remove(universityDegree);
        return await _unitOfWOrk.SaveAsyncAndReturnResult(cancellationToken);
    }
}