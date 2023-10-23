using System.Collections.ObjectModel;
using Domain.Entities.LanguageScore;

namespace Domain.Repositories;

public interface ILanguageScoreRepository
{
    public Task AddAsync(LanguageCertificationScore languageScore, CancellationToken cancellationToken = default);

    public Task<LanguageCertificationScore?>
        GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<LanguageCertificationScore?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public void Remove(LanguageCertificationScore languageCertificationScore);
    public Task<IReadOnlyList<LanguageCertificationScore>> GetAllScoresWithCertification(
        CancellationToken cancellationToken = default);

}