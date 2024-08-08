using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Models;
using ExpenseTracker.Pages;
using ExpenseTracker.Utilities;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ExpenseTracker.ViewModels
{
    
    public partial class AddExpenseViewModel: ObservableObject
    {
        [ObservableProperty]
        public string? expenseTitle;

        [ObservableProperty]
        public string? expenseDescription;

        [ObservableProperty]
        public string? expenseAmount;

        [ObservableProperty]
        public string? addExpenseErrorMessage;

        [ObservableProperty]
        public IList<ExpenseModel>? expenses = Query.GetAllExpenses();


        [RelayCommand]
        public async void SaveExpenseDetail(EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExpenseTitle) || string.IsNullOrWhiteSpace(ExpenseAmount))
            {
                AddExpenseErrorMessage = "Please make sure to enter Expense Title and Amount to add expense details!";
                return;
            }

            else
            {
                Dictionary<string, object> expenseListPageNavigationParameter = new Dictionary<string, object>
                {
                    {nameof(ExpenseListPage),typeof(ExpenseListPage)}
                };

                ExpenseModel expense = new ExpenseModel(ExpenseTitle, ExpenseDescription, Convert.ToDecimal(ExpenseAmount));
                Query.StoreExpense(expense);

                await Shell.Current.GoToAsync(nameof(ExpenseListPage), expenseListPageNavigationParameter);
            }
        }
    }
}
