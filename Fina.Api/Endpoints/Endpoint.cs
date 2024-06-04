using Fina.Api.Common.Api;
using Fina.Api.Endpoints.Categories;
using Fina.Api.Endpoints.Transactions;

namespace Fina.Api;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app){
        var endpoints  = app.MapGroup("");
        // para verificar a disponibilidade da Api
        endpoints.MapGroup("/")
            .WithTags("Heath Check")
            .MapGet("/", () => new { message = "Ok"});
        
        endpoints.MapGroup("v1/categories")
        .WithTags("Categories")
        .MapEndpoint<CreateCategoryEndpoint>()
        .MapEndpoint<UpdateCategoryEndpoint>()
        .MapEndpoint<DeleteCategoryEndpoint>()
        .MapEndpoint<GetAllCategoryEndpoint>()
        .MapEndpoint<GetCategoryByIdEndpoint>();
        

    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) 
        where TEndpoint : IEndpoint 
    {
        TEndpoint.Map(app);
        return app;
    }

}
