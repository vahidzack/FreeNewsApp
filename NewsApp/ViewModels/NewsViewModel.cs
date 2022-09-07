using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NewsApp.Models;
using NewsApp.Services;
using NewsApp.Views;
using Syncfusion.Maui.DataSource.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NewsApp.ViewModels
{
    public partial class NewsViewModel : BaseViewModel
    {
      
        private INewsApiService _newsApiService;
        [ObservableProperty]
         string activeCategory;
        [ObservableProperty]
         ObservableCollection<Category> firstcategories;
        [ObservableProperty]
         ObservableCollection<Category> secondcategories;
        public ObservableCollection<Article> SavedArticles { get; set; } = new(); 

        public  ObservableCollection<Article> Articles { get; private set; } = new();

        public NewsViewModel(INewsApiService newsApiService)
        {
            _newsApiService = newsApiService;
            GenerateCategories();
            activeCategory = "breaking-news";
            _ = GetNews();
        }

        private void GenerateCategories()
        {
            Firstcategories = new ObservableCollection<Category>()
            {
                new Category() {Title="breaking-news",IsSelected=true},
              new Category() {Title="world",IsSelected=false},
              new Category() {Title="nation",IsSelected=false},
              new Category() {Title="business",IsSelected=false},
              new Category() {Title="technology",IsSelected=false}
            };

            Secondcategories = new ObservableCollection<Category>()
            {
                new Category() {Title="entertainment",IsSelected=false},
              new Category() {Title="sports",IsSelected=false},
              new Category() {Title="science ",IsSelected=false},
              new Category() {Title="health",IsSelected=false}
            };
        }

        [RelayCommand]
        async void SelectCategory(Category category)
        {
            activeCategory = category.Title;
            category.IsSelected = true;
            DisableOtherCategory(category);
            await GetNews();
        }
        [RelayCommand]
        void DisableOtherCategory(Category selectedCategory)
        {

            foreach (Category item in firstcategories)
            {
                if (selectedCategory != item) item.IsSelected = false;
                else item.IsSelected = true;
            }

            foreach (Category item in secondcategories)
            {
                if (selectedCategory != item) item.IsSelected = false;
                else item.IsSelected = true;
            }
        }

        [RelayCommand]
        async Task GetNews()
        {
            IsBusy = true;
            NewsModel _news = await _newsApiService.GetNewsAsync(ActiveCategory);
            if (_news != null)
            {
                Articles.Clear();
                foreach (Article item in _news.Articles) Articles.Add(item);
            }
            IsBusy = false;


        }

        [RelayCommand]
        public async Task GoToDetailsPage(Article article)
        {
            if (article is null)
            {
                return;
            } 
            await Shell.Current.GoToAsync(nameof(NewsDetailsPage), true, new Dictionary<string, object>
            {
                {"Article", article}
            });
        }
        [RelayCommand]
        public async Task GetArticlesFromDb()
        {
            var dbArticles = await App.NewsRepository.GetAllArticles();
            if (dbArticles is not null)
            {
                SavedArticles.Clear();
                foreach (var item in dbArticles)
                {
                    SavedArticles.Add(item);
                }
            }
        }

    }
}