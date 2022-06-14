using InfraccionesPedagogicas.BackgroundLoader;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>()
                .AddInfrastructure(hostContext.Configuration);
    })
    .Build();

await host.RunAsync();
