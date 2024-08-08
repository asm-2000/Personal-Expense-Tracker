using ExpenseTracker.Pages;
using ExpenseTracker.ViewModels;

namespace ExpenseTracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }

}
