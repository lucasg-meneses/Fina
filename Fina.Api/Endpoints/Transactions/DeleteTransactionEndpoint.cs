
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Transactions;
using Fina.Core.Response;

namespace Fina.Api.Endpoints.Transactions;

public class DeleteTransactionEndpoint : IEndpoint
{
 public static void Map(IEndpointRouteBuilder app) 
    => app.MapDelete("/{id}", HandleAsync)
        .WithName("Transaction: Delete")
        .WithDescription("Deleta Transação")
        .WithOrder(3)
        .Produces<Response<Transaction?>>();

    public static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
    {
        var request = new DeleteTransactionRequest
        {
            UserId = ApiConfiguration.UserId,
            Id = id,
        };

        var response = await handler.DeleteAsync(request);
        return response.IsSucessul ?
        TypedResults.Ok(response) :
        TypedResults.BadRequest(response);
    }
}