using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Test4.Services;
using Test4.ViewModels;

namespace Test4;
public partial class App : Application
{

    private static IHost __Host;

    public static IHost Host => __Host
        ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

    public static IServiceProvider Services => Host.Services;
    internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
        .AddServices()
        .AddViewModels()
        ;

    protected override async void OnStartup(StartupEventArgs e)
    {
        var host = Host;
        base.OnStartup(e);
        await host.StartAsync();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using var host = Host;
        base.OnExit(e);
        await host.StartAsync();
    }

}

