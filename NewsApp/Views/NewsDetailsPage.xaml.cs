using NewsApp.Models;
using NewsApp.ViewModels;

namespace NewsApp.Views;

[QueryProperty(nameof(Article), "Article")]
public partial class NewsDetailsPage : ContentPage
{
    Article article;
    public Article Article
    {
        get => article;
        set
        {
            article = value;
            this.BindingContext = new NewsDetailsViewModel() { Article = value };
        }
    }

    public NewsDetailsPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}