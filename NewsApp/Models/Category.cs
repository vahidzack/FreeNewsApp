

using CommunityToolkit.Mvvm.ComponentModel;

namespace NewsApp.Models
{
    public partial class Category:ObservableObject 
    {
        [ObservableProperty]
        public string title;
        [ObservableProperty]
        public bool isSelected;

       
    }

}
