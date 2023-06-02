using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Services;
using Store.Services.Abstract;
using Store.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);



string connect = builder.Configuration.GetConnectionString("PersonalConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connect));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddTransient<UnitOfWork>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
