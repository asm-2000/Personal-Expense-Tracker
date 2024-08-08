using ExpenseTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.Utilities;
using ExpenseTracker.Pages;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ExpenseTracker.ViewModels
{
    public partial class ExpenseDetailViewModel: ObservableObject
    {

        [ObservableProperty]
        string? specificExpenseTitle;

        [ObservableProperty]
        public ExpenseModel? specificExpenseDetail;

        public ExpenseDetailViewModel(string specificExpenseTitle)
        {
            SpecificExpenseTitle = specificExpenseTitle;
            SpecificExpenseDetail = new ExpenseModel();
            GetSpecificExpenseDetail();
        }

        public async Task GetSpecificExpenseDetail()
        {
            Debug.WriteLine("Called");
            Debug.WriteLine(SpecificExpenseTitle);
            SpecificExpenseDetail = await Query.GetSpecificExpense(SpecificExpenseTitle);
            
        }

        [RelayCommand]
        public async Task DeleteSpecificDetails()
        {
            Query.DeleteSpecificExpense(SpecificExpenseTitle);
            await Shell.Current.GoToAsync(nameof(ExpenseListPage));
        }
    }
}
