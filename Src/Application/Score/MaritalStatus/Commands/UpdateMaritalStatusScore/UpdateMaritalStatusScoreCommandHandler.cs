using System.Net;
using System.Security.Cryptography.X509Certificates;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Application.Score.MaritalStatus.Commands.UpdateMaritalStatusScore;

public class UpdateMaritalStatusScoreCommandHandler : IRequestHandler<UpdateMaritalStatusScoreCommand, OperationResult<string>>
{
    private readonly IApplicationDbContext _context;

    public UpdateMaritalStatusScoreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OperationResult<string>> Handle(UpdateMaritalStatusScoreCommand request, CancellationToken cancellationToken)
    {
        var maritalStatus = await _context.MaritalStatusScores
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (maritalStatus is null)
        {
            return OperationResult<string>.Failed(Resource.RecordNotFound);
        }

        _context.MaritalStatusScores.Update(maritalStatus);

        await _context.SaveChangesAsync(cancellationToken);

        var rowsAffected = await _context.SaveChangesAsync(cancellationToken);

        if (rowsAffected > 0)
        {
            return OperationResult<string>.Succeeded(((int)HttpStatusCode.Created).ToString());
        }
        else
        {
            return OperationResult<string>.Failed("Record Not Save", (int)HttpStatusCode.Created);
        }
    }
}