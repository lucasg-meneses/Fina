using Fina.Api.Common.Api;
using Fina.Api.Endpoints.Categories;
using Fina.Api.Endpoints.Transactions;

namespace Fina.Api;

public static class EndpointMapping
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        // para verificar a disponibilidade da Api
        endpoints.MapGroup("/")
            .WithTags("Heath Check")
            .MapGet("/", () => new { message = "Ok" });

        endpoints.MapGroup("v1/categories")
            .WithTags("Categories")
            .MapEndpoint<CreateCategoryEndpoint>()
            .MapEndpoint<UpdateCategoryEndpoint>()
            .MapEndpoint<DeleteCategoryEndpoint>()
            .MapEndpoint<GetAllCategoryEndpoint>()
            .MapEndpoint<GetCategoryByIdEndpoint>();
        
        endpoints.MapGroup("v1/transaction")
            .WithTags("Transactions")
            .MapEndpoint<CreateTransactionEndpoint>()
            .MapEndpoint<UpdateTransactionEndpoint>()
            .MapEndpoint<DeleteTransactionEndpoint>()
            .MapEndpoint<GetTransactionByPeriodEndpoint>()
            .MapEndpoint<GetTransactionByIdEndpoint>();

    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }

}
