using APP1.DbContexts;
using APP1.Repositorios;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conectar

var connectionString = builder.Configuration.GetConnectionString("AccountDB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// INYECCION

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{

    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();


}));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
