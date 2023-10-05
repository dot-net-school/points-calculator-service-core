using Application.Common.Interfaces;
using MediatR;
using Shared;
using System.Net;

namespace Application.Score.MaritalStatus.Commands.DeleteMaritalStatusScore;

public class
    DeleteMaritalStatusScoreCommandHandler : IRequestHandler<DeleteMaritalStatusScoreCommand, OperationResult<string>>
{
    private readonly IApplicationDbContext _context;

    public DeleteMaritalStatusScoreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OperationResult<string>> Handle(DeleteMaritalStatusScoreCommand request,
        CancellationToken cancellationToken)
    {
        var maritalStatus = await _context.MaritalStatusScores.FindAsync(request.Id, cancellationToken);

        if (maritalStatus is null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound);
        }

        _context.MaritalStatusScores.Remove(maritalStatus);

        var rowsAffected = await _context.SaveChangesAsync(cancellationToken);

        if (rowsAffected > 0)
        {
            return OperationResult<string>.Succeeded(((int)HttpStatusCode.Created).ToString());
        }
        else
        {
            return OperationResult<string>.Failed("Record Not Remove", (int)HttpStatusCode.Created);
        }
    }
}