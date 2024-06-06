using Fina.Api;
using Fina.Api.Common.Api;

var builder = WebApplication.CreateBuilder(args);
//Add
builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if(app.Environment.IsDevelopment()){
    app.ConfigureDevEnviroment();
}
app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();
app.Run();
