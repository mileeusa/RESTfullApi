var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/health", () =>
{
    var health = new
    {
        status = "healthy",
        cpu = new Random().Next(1, 100),  // Replace with real CPU usage
        mem = (int)(GC.GetTotalMemory(false) / (1024 * 1024)), // MB usage
        errors = 2
    };
    return Results.Ok(health);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
