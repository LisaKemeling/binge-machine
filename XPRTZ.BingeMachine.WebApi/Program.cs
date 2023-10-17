using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure;
using XPRTZ.BingeMachine.Shows.Database.Infrastructure.Builders;
using XPRTZ.BingeMachine.Shows.TvMaze.Infrastructure;
using XPRTZ.BingeMachine.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterSqlinfrastructure(builder.Configuration);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BingeMachine API",
        Version = "v1"
    });
});


builder.Services.AddHttpClient<ITvMazeHttpClient, TvMazeHttpClient>(c =>
{
    c.BaseAddress = new Uri("https://api.tvmaze.com");
});

//Autofac
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterAutofacModules(builder);
});

var app = builder.Build();

app.Services.GetRequiredService<ShowsDbContext>().PrepareDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
        {
            ["activated"] = false
        };
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program{ }