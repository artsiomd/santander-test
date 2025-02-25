using Microsoft.AspNetCore.Mvc;
using Santander.Test.Application.Services.Abstractions;

namespace Santander.Test.RestAPI;

public static class StoryEndpoints
{
    public static void MapStoryEndpoints(this IEndpointRouteBuilder app)
    {
        var storiesGroup = app.MapGroup("/stories");
        storiesGroup.MapGet("/", async (int? count, [FromServices] IStoryService service) =>
        {
            var stories = await service.GetBestStoriesAsync(count);
            return TypedResults.Ok(stories);
        });
    }
}