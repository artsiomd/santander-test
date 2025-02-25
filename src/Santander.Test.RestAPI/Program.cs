using Santander.Test.Application;
using Santander.Test.Infrastructure.Redis;
using Santander.Test.RestAPI;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddOutputCache(builder.Configuration);
builder.Services
    .AddStoryApiApplication()
    .AddStoryPersistance(builder.Configuration);

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.UseOutputCache();
app.MapStoryEndpoints();

app.Run();
