using Microsoft.Extensions.DependencyInjection;

namespace Test4.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
       ;
    }
}
