using NewsApp.ViewModels;

namespace NewsApp.Views;

public partial class NewsPage : ContentPage
{

    public NewsPage(NewsViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

	private void NewsTabView_SelectionChanged(object sender, Syncfusion.Maui.TabView.TabSelectionChangedEventArgs e)
	{
		if(e.NewIndex == 0)
		{
			suggestedNewItem.TextColor = Color.FromArgb("#FFFFFF");
			SavedNewsItems.TextColor = Color.FromArgb("#2B4865");
		}
		else
		{
            suggestedNewItem.TextColor = Color.FromArgb("#2B4865");
            SavedNewsItems.TextColor = Color.FromArgb("#FFFFFF");
        }
	}

}