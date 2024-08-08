using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Pages;
using System.Diagnostics;

namespace ExpenseTracker.ViewModels
{
    public partial class MainViewModel: ObservableObject
    { 
        [ObservableProperty]
        public string? userName;

        [ObservableProperty]
        public string? userNameErrorMessage;

        [RelayCommand]
        public async void Continue(EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(UserName))
            {
                UserNameErrorMessage = "Please Enter Your Name Before Continuing!";
                return;
            }

            else
            {
                Dictionary<string, object> expenseListPageNavigationParameter = new Dictionary<string, object>
                {
                    {nameof(ExpenseListPage), typeof(ExpenseListPage)}
                };

                await Shell.Current.GoToAsync(nameof(ExpenseListPage), expenseListPageNavigationParameter);
            }
        }
    }
}
