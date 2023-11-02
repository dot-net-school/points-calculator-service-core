using System.Net;
using Application.Common.Mappers;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.UniversityDegree.Queries;

public sealed class GetSingleUniversityDegreeQueryHandler: IRequestHandler<GetSingleUniversityDegreeQuery,OperationResult<GetUniversityDegreeDto>>
{
    private readonly IUniversityDegreeRepository _universityDegreeRepository;

    public GetSingleUniversityDegreeQueryHandler(IUniversityDegreeRepository universityDegreeRepository)
    {
        _universityDegreeRepository = universityDegreeRepository;
    }

    public async Task<OperationResult<GetUniversityDegreeDto>> Handle(GetSingleUniversityDegreeQuery request
        , CancellationToken cancellationToken=default)
    {
        var universityDegree = await _universityDegreeRepository
            .GetByIdAsyncAsNoTracking(Guid.Parse(request.Id),cancellationToken);
        if (universityDegree is null)
        {
            return OperationResult<GetUniversityDegreeDto>.Failed(Resource.NoRecords, HttpStatusCode.NotFound);
        }
        var mapper = new UniversityDegreeDtoMapper();
        var universityDegreeDto=mapper.Mapper(universityDegree);
        
        return OperationResult<GetUniversityDegreeDto>.Succeeded(universityDegreeDto,Resource.Success, HttpStatusCode.Found);


        // var universityDegrees = await _universityDegreeRepository.ListAllAsync(cancellationToken);
        // if (universityDegrees.Any())
        // {
        //     return OperationResult<>
        // }

        //Select Universities from DB
        //Sort them then

    }
}