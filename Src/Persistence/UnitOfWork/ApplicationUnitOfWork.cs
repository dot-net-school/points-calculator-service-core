using System.Net;
using Application.Common;
using Domain.Common;
using Shared;

namespace Persistence.UnitOfWork;

public class ApplicationUnitOfWork : IApplicationUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public ApplicationUnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
        GC.SuppressFinalize(this);
    }

    public async Task<OperationResult<int>> SaveAsyncAndReturnResult(CancellationToken cancellationToken = default)
    {
        //Exceptions will handle in global Exception handling error
        int result = await _context.SaveChangesAsync(cancellationToken);
        return OperationResult<int>.Succeeded(result, Resource.Success, HttpStatusCode.Created);
    }
}