using ShEC.UMS.Infrastructure;
using ShEC.UMS.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/health", () =>
    Results.Ok(new { status = "Healthy" }))
    .WithName("HealthCheck");

app.MapGet("/health/database", async (
    ShECUmsDbContext db,
    CancellationToken cancellationToken) =>
{
    var canConnect = await db.Database.CanConnectAsync(
        cancellationToken);

    return canConnect
        ? Results.Ok(new
        {
            status = "Healthy",
            database = "PostgreSQL"
        })
        : Results.StatusCode(
            StatusCodes.Status503ServiceUnavailable);
})
.WithName("DatabaseHealthCheck");

app.Run();
