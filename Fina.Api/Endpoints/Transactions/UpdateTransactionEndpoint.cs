
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Transactions;
using Fina.Core.Response;

namespace Fina.Api.Endpoints.Categories;

public class UpdateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPut("/{id}", HandleAsync)
            .WithName("Transaction: Update")
            .WithDescription("Atualiza transação")
            .WithOrder(2)
            .Produces<Response<Transaction?>>();

    public static async Task<IResult> HandleAsync(
        ITransactionHandler handler,
        UpdatedTransactionRequest request,
        long id)
    {
        request.UserId = ApiConfiguration.UserId;
        request.Id = id;

        var response = await handler.UpdateAsync(request);
        return response.IsSucessul ?
        TypedResults.Ok(response) :
        TypedResults.BadRequest(response);
    }
}
