using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Salon_service.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<tableContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")
    ));
builder.Services.AddDbContext<tableC1>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")
    ));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
     );
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
