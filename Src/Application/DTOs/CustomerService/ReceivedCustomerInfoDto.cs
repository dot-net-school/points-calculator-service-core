using Application.DTOs.Language;
using Application.DTOs.UniversityDegree;

namespace Application.DTOs.CustomerService;

public record ReceivedCustomerInfoDto(string? Id, int? Age, ReceivedMaritalDto? Marital, List<ReceivedUniversityDegreesDto>? UniversityDegrees,
    List<ReceivedLanguageDegreeDto>? LanguageDegrees, int? JobExperience);
public record ReceivedMaritalDto(int? Status, int? SpouseStatus);