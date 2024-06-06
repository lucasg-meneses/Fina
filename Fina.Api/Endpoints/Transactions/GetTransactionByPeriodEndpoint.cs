
using Fina.Api.Common.Api;
using Fina.Core;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Transactions;
using Fina.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.Endpoints.Transactions;

public class GetTransactionByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
      => app.MapGet("/", HandlerAsync)
          .WithName("Transaction: Get by Period")
          .WithDescription("Lista as transações")
          .WithOrder(5)
          .Produces<Response<Transaction?>>();


    public static async Task<IResult> HandlerAsync(
        ITransactionHandler handler,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetTransactionByPeriodRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate,
            UserId = ApiConfiguration.UserId
        };

        var response = await handler.GetByPeriodAsync(request);
        return response.IsSucessul ?
            TypedResults.Ok(response) :
            TypedResults.BadRequest(response);
    }
}
