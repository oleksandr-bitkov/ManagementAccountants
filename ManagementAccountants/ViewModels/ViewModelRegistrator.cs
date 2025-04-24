﻿using Microsoft.Extensions.DependencyInjection;

namespace ManagementAccountants.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
       ;
    }
}
