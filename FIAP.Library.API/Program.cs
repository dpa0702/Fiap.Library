using FIAP.Library.API.Services.Interfaces;
using FIAP.Library.API.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var configuration = builder.Configuration;
var server = configuration.GetSection("MassTransit")["Server"] ?? string.Empty;
var user = configuration.GetSection("MassTransit")["User"] ?? string.Empty;
var password = configuration.GetSection("MassTransit")["Password"] ?? string.Empty;

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(server, "/", h =>
        {
            h.Username(user);
            h.Password(password);
        });

        cfg.ConfigureEndpoints(context);
    });
});

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