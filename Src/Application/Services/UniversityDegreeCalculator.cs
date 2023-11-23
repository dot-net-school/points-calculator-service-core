using Application.Common.Interfaces;
using Application.DTOs.CustomerService;
using Application.DTOs.MainScore;
using Application.DTOs.UniversityDegree;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public sealed class UniversityDegreeCalculator : IScoreStrategy
    {
        private readonly IUniversityDegreeRepository _universityDegreeRepository;

        public UniversityDegreeCalculator(IUniversityDegreeRepository universityDegreeRepository)
        {
            _universityDegreeRepository = universityDegreeRepository;
        }

        public async Task<ScoreDataDto> CalculateScore(ReceivedCustomerInfoDto input,
            CancellationToken cancellationToken = default)
        {
            if (IsEmpty(input))
            {
                return NoRecordResult();
            }

            List<ReceivedUniversityDegreesDto> universityDegreeDtoList = input.UniversityDegrees;
            if (!universityDegreeDtoList.Any())
            {
                return NoRecordResult();
            }

            List<ReceivedUniversityDegreesDto?> universityDegreesDtos = universityDegreeDtoList;

            IReadOnlyList<UniversityDegree?> universityDegreeModels =
                await _universityDegreeRepository.ListAllAsync(cancellationToken);

            List<ScoreDataDto?> degreeResultDto = CalculateDegreesScores(universityDegreesDtos, universityDegreeModels);

            ScoreDataDto? universityDegreeResultDto = degreeResultDto.MaxBy(ud => ud.Score) ?? NoRecordResult();
            return universityDegreeResultDto;
        }

        private bool IsEmpty(ReceivedCustomerInfoDto input)
        {
            if (input is null)
            {
                return true;
            }

            if (input.UniversityDegrees is null)
            {
                return true;
            }
            
            if (!input.UniversityDegrees.Any())
            {
                return true;
            }

            return false;
        }

        private static List<ScoreDataDto?> CalculateDegreesScores(
            List<ReceivedUniversityDegreesDto?> universityDegreesDtos,
            IReadOnlyList<UniversityDegree?> universityDegreeModels)
        {
            List<ScoreDataDto?> degreeResultDto = new List<ScoreDataDto?>();
            foreach (var universityDegreesDto in universityDegreesDtos)
            {
                foreach (var universityDegreeModel in universityDegreeModels)
                {
                    if (universityDegreesDto != null &&
                        Guid.Parse(universityDegreesDto.Id) == universityDegreeModel?.Id)
                    {
                        ScoreDataDto? universityDegreeResultDtoTemp =
                            new ScoreDataDto(
                                $"Score For {universityDegreeModel.UniversityName} University And {universityDegreeModel.DegreeName} Degree",
                                universityDegreeModel.Score.Value);
                        degreeResultDto.Add(universityDegreeResultDtoTemp);
                    }
                }
            }
            return degreeResultDto;
        }

        private ScoreDataDto NoRecordResult()
        {
            ScoreDataDto scoreDataDto = new ScoreDataDto("No Record Found For University UniversityDegrees", 0);
            return scoreDataDto;
        }
    }
}