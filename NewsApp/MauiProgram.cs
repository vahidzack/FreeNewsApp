
using Microsoft.Extensions.DependencyInjection.Extensions;
using NewsApp.Helpers;
using NewsApp.Services;
using NewsApp.ViewModels;
using NewsApp.Views;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.ListView.Hosting;

namespace NewsApp;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Roboto-Italic.ttf", "Roboto1");
				fonts.AddFont("Roboto-Medium.ttf", "Roboto2");
				fonts.AddFont("Roboto-ThinItalic.ttf", "Roboto3");
				fonts.AddFont("vtksstorm.ttf", "vtk1");
				
			});
		string dbpath = FileAccessHelper.GetLocalPath("News.db3");
		builder.Services.AddSingleton<NewsRepository>(s=>ActivatorUtilities.CreateInstance<NewsRepository>(s,dbpath));
		builder.Services.AddSingleton<INewsApiService,NewsApiService>();
        builder.Services.AddSingleton<NewsViewModel>();
        builder.Services.AddSingleton<NewsPage>();
		builder.Services.AddTransient<NewsDetailsViewModel>();
		builder.Services.AddTransient<NewsDetailsPage>();
        builder.ConfigureSyncfusionListView();
        return builder.Build();
	}
}
