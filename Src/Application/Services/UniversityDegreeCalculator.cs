using Application.Common.Interfaces;
using Application.DTOs.UniversityDegree;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public sealed class UniversityDegreeCalculator : IScoreCalculatorService<UniversityDegreeDtoList, UniversityDegreeDtoList>
    {
        private readonly IUniversityDegreeRepository _universityDegreeRepository;

        public UniversityDegreeCalculator(IUniversityDegreeRepository universityDegreeRepository)
        {
            _universityDegreeRepository = universityDegreeRepository;
        }

        public async Task<UniversityDegreeDtoList> CalculateScore(UniversityDegreeDtoList universityDegreeDtoList,
            CancellationToken cancellationToken = default)
        {
            List<UniversityDegreesDto?> universityDegreesDtos = universityDegreeDtoList.UniversityDegreesDto;

            IReadOnlyList<UniversityDegree?> universityDegreeModels =
                await _universityDegreeRepository.ListAllAsync(cancellationToken);

            List<UniversityDegreeResultDto?> degreeResultDto = CalculateDegrees(universityDegreesDtos, universityDegreeModels);

            UniversityDegreeResultDto? universityDegreeResultDto = degreeResultDto.MaxBy(ud => ud.Score);

            if (universityDegreeResultDto == null)
            {
                universityDegreeResultDto = new UniversityDegreeResultDto("No UniversityName", "No DegreeName", 0);
            }

            universityDegreeDtoList.UniversityDegreeResultDto = universityDegreeResultDto;

            return universityDegreeDtoList;
        }

        private static List<UniversityDegreeResultDto?> CalculateDegrees(List<UniversityDegreesDto?> universityDegreesDtos, IReadOnlyList<UniversityDegree?> universityDegreeModels)
        {
            List<UniversityDegreeResultDto?> degreeResultDto = new List<UniversityDegreeResultDto?>();

            foreach (var universityDegreesDto in universityDegreesDtos)
            {
                foreach (var universityDegreeModel in universityDegreeModels)
                {
                    if (universityDegreesDto != null && universityDegreesDto.Id == universityDegreeModel?.Id)
                    {
                        UniversityDegreeResultDto? universityDegreeResultDtoTemp =
                            new UniversityDegreeResultDto(universityDegreeModel.UniversityName,
                                universityDegreeModel.DegreeName, universityDegreeModel.Score.Value);
                        degreeResultDto.Add(universityDegreeResultDtoTemp);
                    }
                }
            }

            return degreeResultDto;
        }
    }
}
