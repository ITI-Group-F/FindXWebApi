using FindX.WebApi.Extenstions;
using Serilog;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Custom Services
builder.ConfigureAppSettings();
builder.ConfigureSerilog();
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
builder.Host.UseSerilog();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.RegisterMongoDb();
builder.RegisterServices();
#endregion
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
