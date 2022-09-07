using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsApp.Models;


namespace NewsApp.ViewModels
{
    public partial class NewsDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        Article article;
      

        /// <summary> 
        /// Its the Back Method ++++++++++++++
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..", true);
        }


        /// <summary>
        /// For Sharing Informations
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task ShareNews()
        { 

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = Article.Content,
                Title = Article.Title,
            });
        }

        [RelayCommand]
        async Task BookmarkArticles()
        {
            await App.NewsRepository.AddNewArticle(Article);
            await Shell.Current.DisplayAlert("Successs", $"{Article.Title} has been added to DB", "OK");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var data = query.FirstOrDefault();
            var Article = data.Value as Article;          
        }
    }
}
