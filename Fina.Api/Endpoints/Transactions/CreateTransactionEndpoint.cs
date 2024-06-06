
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Transactions;
using Fina.Core.Response;

namespace Fina.Api.Endpoints.Transactions;

public class CreateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
       => app.MapPost("/", HandleAsync)
           .WithName("Transaction: Created")
           .WithDescription("Cadastra transação")
           .WithOrder(1)
           .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, CreateTransactionRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
        var response = await handler.CreateAsync(request);
        return response.IsSucessul ?
        TypedResults.Created($"v1/transaction/{response.Data?.Id}", response)
        : TypedResults.BadRequest(response);
    }
}
