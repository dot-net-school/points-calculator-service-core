using Domain.Common;
using Domain.Entities;
using Domain.Entities.LanguageScore;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Application.Common;

public interface IUnitOfWOrk : IDisposable, IAsyncDisposable
{
    public Task<OperationResult<int>> SaveAsyncAndReturnResult( CancellationToken cancellationToken = default);
}

public interface IApplicationUnitOfWork : IUnitOfWOrk
{
    
}