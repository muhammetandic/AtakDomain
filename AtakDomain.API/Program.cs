using AtakDomain.API.Middleware;
using AtakDomain.API.Services;
using AtakDomain.Common.Intarfaces;
using AtakDomain.Persistence;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(configuration);
builder.Services.AddScoped(typeof(IHistoryService), typeof(HistoryService));
builder.Services.AddScoped(typeof(IBestSellerService), typeof(BestSellerService));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCustomExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();