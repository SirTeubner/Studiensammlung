using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Studiensammlung.Lib;
using Studiensammlung.StudiensammlungApp.Pages;
using Studiensammlung.StudiensammlungApp.Services;
using Studiensammlung.StudiensammlungCore.ViewModels;
using Studiensammlung.StudiensammlungCore.Services;
using Syncfusion.Maui.Core.Hosting;

namespace Studiensammlung.StudiensammlungApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<StatisticViewModel>();
            builder.Services.AddSingleton<StatisticPage>();

            string path = FileSystem.Current.AppDataDirectory;
            string filename = "data.sqlite";
            string fullpath = Path.Combine(path, filename);

            System.Diagnostics.Debug.WriteLine(fullpath);


            builder.Services.AddSingleton<IRepository>(new SqliteRepository(fullpath));

            builder.Services.AddSingleton<IAlertService, AlertService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
