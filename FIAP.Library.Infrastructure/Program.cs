using FIAP.Library.Infrastructure.Data;
using FIAP.Library.Infrastructure.Repositories;
using FIAP.Library.Infrastructure.Repositories.Interfaces;
using FIAP.Library.Infrastructure.Services;
using FIAP.Library.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddScoped<IRentBookRepository, RentBookRepository>();
builder.Services.AddScoped<IRentBookService, RentBookService>();

builder.Services.AddDbContext<MSContext>(
    op => op.UseSqlServer(builder.Configuration.GetConnectionString("Context")
    ?? throw new InvalidOperationException("Connection string not found")));

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