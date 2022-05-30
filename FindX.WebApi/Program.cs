using FindX.WebApi.Extenstions;
using FindX.WebApi.Settings;
using FindX.WebApi.Model;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Custom Services

builder.ConfigureAppSettings();
builder.ConfigureSerilog();
builder.Host.UseSerilog();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.RegisterMongoDb();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole>(
   MongoDbSettings.ConnectionString
    );



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
