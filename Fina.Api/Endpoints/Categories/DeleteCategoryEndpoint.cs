
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Categories;
using Fina.Core.Response;

namespace Fina.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) 
    => app.MapDelete("/{id}", HandleAsync)
        .WithName("Categories: Delete")
        .WithDescription("Deleta categoria")
        .WithOrder(3)
        .Produces<Response<Category?>>();

    public static async Task<IResult> HandleAsync(ICategoryHandler handler, long id)
    {
        var request = new DeleteCategoryRequest
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
