using Microsoft.Extensions.DependencyInjection;
using RefactorCodeChallenge;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IEntryPoint, EntryPoint>()
    .BuildServiceProvider();

var entryPoint = serviceProvider.GetRequiredService<IEntryPoint>();

entryPoint.Run();