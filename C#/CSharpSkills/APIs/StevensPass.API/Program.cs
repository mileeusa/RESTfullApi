using StevensPass.API.BackgroundJobs;
using StevensPass.API.Services;

var builder = WebApplication.CreateBuilder(args);

// ---------- Framework ----------
builder.Services.AddControllers();

// ---------- Infrastructure ----------
builder.Services.AddMemoryCache();

// ---------- Application Services ----------
builder.Services.AddScoped<IRoadService, RoadService>();
builder.Services.AddScoped<IMountainPassService, MountainPassService>();
builder.Services.AddScoped<IStatusService, StatusService>();

builder.Services.AddHostedService<DataRefreshWorker>();

// Swagger (Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
