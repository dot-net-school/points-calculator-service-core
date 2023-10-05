using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Shared;
using System.Net;

namespace Application.Score.MaritalStatus.Commands.CreateMaritalStatusScore;

public class CreateMaritalStatusScoreCommandHandler : IRequestHandler<CreateMaritalStatusScoreCommand, OperationResult<string>>
{
    private readonly IApplicationDbContext _context;

    public CreateMaritalStatusScoreCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OperationResult<string>> Handle(CreateMaritalStatusScoreCommand request, CancellationToken cancellationToken)
    {
        var maritalStatus = new MaritalStatusScore
        {
            MaritalStatus = request.MaritalStatus,
            Score = request.Score
        };

        _context.MaritalStatusScores.Add(maritalStatus);

        var rowsAffected = await _context.SaveChangesAsync(cancellationToken);

        if (rowsAffected > 0 )
        {
            return OperationResult<string>.Succeeded(((int)HttpStatusCode.Created).ToString());
        }
        else
        {
            return OperationResult<string>.Failed("Record Not Save", (int)HttpStatusCode.Created);
        }

        
    }
}