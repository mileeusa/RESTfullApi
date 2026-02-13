using dotnet_etcd;
using dotnet_etcd.DependencyInjection;
using EtcdImpl.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. Add EtcdClient (Standard DI registration provided by the library)
// It automatically handles connection pooling and basic retries.
builder.Services.AddEtcdClient(options =>
{
    options.ConnectionString = builder.Configuration["Etcd:ConnectionString"] ?? "http://localhost:2379";
    options.UseInsecureChannel = true; // Use false for HTTPS
});

// 2. Register your wrapper service
builder.Services.AddSingleton<IEtcdService, EtcdService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
