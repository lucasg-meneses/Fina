using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Categories;
using Fina.Core.Response;

namespace Fina.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) 
    => app.MapPost("/", HandleAsync)
        .WithName("")
        .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, CreateCategoryRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
        var response = await handler.CreateAsync(request);
        return response.IsSucessul ?
        TypedResults.Created($"v1/categories/{response.Data?.Id}", response)
        : TypedResults.BadRequest(response);
    }
}
