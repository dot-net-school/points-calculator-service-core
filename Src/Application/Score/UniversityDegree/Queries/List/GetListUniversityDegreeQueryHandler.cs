using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Common.Mappers;
using Domain.Repositories;
using MediatR;
using Shared;

namespace Application.Score.UniversityDegree.Queries.List;

public class GetListUniversityDegreeQueryHandler:IRequestHandler<GetListUniversityDegreeQuery,OperationResult<List<GetUniversityDegreeDto>>>
{
    private readonly IUniversityDegreeRepository _universityDegreeRepository;

    public GetListUniversityDegreeQueryHandler(IUniversityDegreeRepository universityDegreeRepository)
    {
        _universityDegreeRepository = universityDegreeRepository;
    }

    public async Task<OperationResult<List<GetUniversityDegreeDto>>> Handle(GetListUniversityDegreeQuery request
        , CancellationToken cancellationToken=default)
    {
        List<GetUniversityDegreeDto> _universityDegreeList = await FetchAndMap(cancellationToken);
        if (!_universityDegreeList.Any())
        {
            return OperationResult<List<GetUniversityDegreeDto>>.Failed(Resource.NoRecords, HttpStatusCode.NotFound);
        }
        return OperationResult<List<GetUniversityDegreeDto>>.Succeeded(_universityDegreeList,Resource.Success, HttpStatusCode.Found);
    }

    private async Task<List<GetUniversityDegreeDto>> FetchAndMap(CancellationToken cancellationToken=default)
    {
        var universityDegreeList = await _universityDegreeRepository.ListAllAsync(cancellationToken);
        var mapper = new UniversityDegreeDtoMapper();
        return mapper.ListMapper(universityDegreeList);
    }
}