using ExpenseTracker.Pages;
using ExpenseTracker.ViewModels;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<ExpenseListViewModel>();
            builder.Services.AddSingleton<AddExpenseViewModel>();
            builder.Services.AddSingleton<ExpenseDetailViewModel>();

            builder.Services.AddTransient<ExpenseListPage>();
            builder.Services.AddTransient<AddExpensePage>();
            builder.Services.AddTransient<ExpenseDetailPage>();
            
#endif
            return builder.Build();
        }
    }
}
