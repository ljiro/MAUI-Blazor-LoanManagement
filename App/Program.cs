using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using LoanManagement.Infrastructure.Repositories;
using LoanManagement.Services;
using LoanManagement.Web.Stores.Loan.Effects;
using Microsoft.Extensions.Logging;

namespace LoanManagement;

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
                fonts.AddFont("fa-solid-900.ttf", "FontAwesome");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        // Register services
        builder.Services.AddSingleton<ILoanRepository, MockLoanRepository>();
        builder.Services.AddScoped<ILoanService, LoanService>();

        // Configure Fluxor
        builder.Services.AddFluxor(options =>
        {
            options.ScanAssemblies(typeof(MauiProgram).Assembly);
#if DEBUG
            options.UseReduxDevTools();
#endif
        });

        return builder.Build();
    }
}