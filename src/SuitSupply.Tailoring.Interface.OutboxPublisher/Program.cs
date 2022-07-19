using SuitSupply.Tailoring.Interface.OutboxPublisher;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<OutboxWorker>();
    })
    .Build();

await host.RunAsync();
