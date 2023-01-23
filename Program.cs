using Microsoft.EntityFrameworkCore;
using WebApi_Control_Production.Connection;
using WebApi_Control_Production.Repository_s;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>//usamos injeccion de dependencias hago referencia 
{														//a DbContext y conecto con mi cadena de conexion
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductionRepositorio,ProductionRepository>();
//esta linea me permite utilizar Interface y Repository

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
