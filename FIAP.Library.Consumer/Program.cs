using FIAP.Library.Consumer;
using FIAP.Library.Consumer.Events;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var newReservationQueue = configuration.GetSection("MassTransit")["NewReservationQueue"] ?? string.Empty;
        var server = configuration.GetSection("MassTransit")["Server"] ?? string.Empty;
        var user = configuration.GetSection("MassTransit")["User"] ?? string.Empty;
        var password = configuration.GetSection("MassTransit")["Password"] ?? string.Empty;

        services.AddHostedService<Worker>();

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(server, "/", h =>
                {
                    h.Username(user);
                    h.Password(password);
                });


                cfg.ReceiveEndpoint(newReservationQueue, e =>
                {
                    e.Consumer<NewRentalEvent>();
                });

                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<NewRentalEvent>();
        });
    })
    .Build();

host.Run();