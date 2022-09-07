using NewsApp.Services;

namespace NewsApp;

public partial class App : Application
{
	public static NewsRepository NewsRepository { get; private set; }
	public App( NewsRepository newsRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();
        NewsRepository = newsRepository;	
	}
}
