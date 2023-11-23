using Application.DTOs.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Application.Common.Interfaces;

public interface IGetCustomerAdapter
{
    public Task<ReceivedCustomerInfoDto?> SendAsync(string id);
}