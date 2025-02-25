using Santander.Test.Application;
using Santander.Test.Infrastructure.Redis;
using Santander.Test.RestAPI;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
    .AddStoryApiApplication()
    .AddStoryPersistance(builder.Configuration);

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapStoryEndpoints();

app.Run();
