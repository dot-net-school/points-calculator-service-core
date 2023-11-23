using System.Net;
using Application.Common.Interfaces;
using Application.DTOs.CustomerService;
using Application.DTOs.Language;
using Application.DTOs.MainScore;
using Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Shared;

namespace Application.Score.TotalScore;

public sealed class TotalScoreQueryHandler : IRequestHandler<TotalScoreQuery, OperationResult<CalculatedMainScoreDto>>
{
    private readonly IValidator<ReceivedCustomerInfoDto> _validator;
    private readonly TotalScoreCalculator _totalScoreCalculator;
    private readonly IGetCustomerAdapter _customerAdapter;

    public TotalScoreQueryHandler(IGetCustomerAdapter customerAdapter , TotalScoreCalculator totalScoreCalculator, IValidator<ReceivedCustomerInfoDto> validator)
    {
        _customerAdapter = customerAdapter;
        _totalScoreCalculator = totalScoreCalculator;
        _validator = validator;
    }

    public async Task<OperationResult<CalculatedMainScoreDto>> Handle(TotalScoreQuery request, CancellationToken cancellationToken=default)
    {
        //TODO we need validation for value types in every dto ,maybe its possible with aggregate root domain model
        ReceivedCustomerInfoDto? returnedCustomerInfoDto = await _customerAdapter.SendAsync(request.Id);
        
        if (returnedCustomerInfoDto is null)
        {
            return OperationResult<CalculatedMainScoreDto>.Failed(Resource.Fail, HttpStatusCode.ExpectationFailed);
        }
        var validationResult = _validator.Validate(returnedCustomerInfoDto);
        if (!validationResult.IsValid)
        {
            return OperationResult<CalculatedMainScoreDto>.Failed( string.Join(", ", validationResult.Errors), HttpStatusCode.ExpectationFailed);
        }
        
        return await _totalScoreCalculator.Calculate(returnedCustomerInfoDto,cancellationToken);
    }
}