using Santander.Test.Application;
using Santander.Test.Infrastructure.HackerNews;
using Santander.Test.Infrastructure.Redis;
using Santander.Test.Worker;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddStoryWorkerApplication()
    .AddStoryPersistance(builder.Configuration)
    .AddHackerNewsProvider();

builder.Services.AddHostedService<StoryTrackerBackgroundService>();

var app = builder.Build();
app.Run();
