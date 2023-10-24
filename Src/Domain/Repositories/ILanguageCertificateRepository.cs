using System.Collections.ObjectModel;
using Domain.Entities.LanguageScore;

namespace Domain.Repositories;

public interface ILanguageCertificateRepository
{
    public Task AddAsync(LanguageCertification languageCertification , CancellationToken cancellationToken = default);
    public Task<LanguageCertification?> GetByIdWithScoreAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<LanguageCertification?> GetByIdAsNoTrackingWithScoreAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<LanguageCertification?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<LanguageCertification?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default);
    
    public Task<IReadOnlyList<LanguageCertification>> GetAllWithScoreAsync(CancellationToken cancellationToken = default);
    public void Remove(LanguageCertification languageCertification);

}