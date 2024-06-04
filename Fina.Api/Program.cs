using Fina.Api;
using Fina.Api.Data;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// conexão banco
const string connectionString = @"Host=localhost,5432;Username=postgres;Password=1234;Database=fina";
builder.Services.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString));
// handlers config
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
