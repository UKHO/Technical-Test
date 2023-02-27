using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IEntryPoint, EntryPoint>()
    .BuildServiceProvider();

var entryPoint = serviceProvider.GetRequiredService<IEntryPoint>();

entryPoint.PrintChart();