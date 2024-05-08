using FIAP.Library.InvoiceMS.Data;
using FIAP.Library.InvoiceMS.Repositories;
using FIAP.Library.InvoiceMS.Repositories.Interfaces;
using FIAP.Library.InvoiceMS.Services;
using FIAP.Library.InvoiceMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();

builder.Services.AddDbContext<InvoiceMSContext>(
    op => op.UseSqlServer(builder.Configuration.GetConnectionString("InvoiceContext")
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
