using Application.DTOs.Language;
using Application.DTOs.UniversityDegree;

namespace Application.DTOs.MainScore;

public record CalculatedMainScoreDto(int Total,List<ScoreDataDto> Items);
