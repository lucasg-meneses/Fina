
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Categories;
using Fina.Core.Response;

namespace Fina.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPut("/{id}", HandleAsync)
            .WithName("Categories: Update")
            .WithDescription("Atualiza categoria")
            .WithOrder(2)
            .Produces<Response<Category?>>();

    public static async Task<IResult> HandleAsync(
        ICategoryHandler handler, 
        UpdatedCategoryRequest request, 
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
