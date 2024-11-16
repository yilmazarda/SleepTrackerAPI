using Microsoft.EntityFrameworkCore;
using sleep_tracker_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<SleepContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISleepRepository, SleepRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:60280") // Allow Angular app and localhost frontend
              .AllowAnyMethod()                        // Allow any HTTP method (GET, POST, etc.)
              .AllowAnyHeader();                       // Allow any headers
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}
app.UseCors("AllowSpecificOrigins");
app.UseCors("AllowAngularApp");
app.MapControllers();
app.Run();
