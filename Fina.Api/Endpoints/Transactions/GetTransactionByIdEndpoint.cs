
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Transactions;
using Fina.Core.Response;

namespace Fina.Api.Endpoints.Transactions;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
       => app.MapGet("/{id}", HandlerAsync)
           .WithName("Transaction: Get by Id")
           .WithDescription("exibe a Transação")
           .WithOrder(5)
           .Produces<Response<Transaction?>>();


    public static async Task<IResult> HandlerAsync(
        ITransactionHandler handler,
        long id)
    {
        var request = new GetTransactionByIdRequest
        {
            Id = id,
            UserId = ApiConfiguration.UserId
        };

        var response = await handler.GetByIdAsync(request);
        return response.IsSucessul ?
            TypedResults.Ok(response) :
            TypedResults.BadRequest(response);
    }
}
