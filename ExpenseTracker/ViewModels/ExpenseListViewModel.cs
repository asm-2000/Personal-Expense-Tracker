using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Models;
using ExpenseTracker.Pages;
using ExpenseTracker.Utilities;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ExpenseTracker.ViewModels
{
    public partial class ExpenseListViewModel : ObservableObject
    {
        public IList<ExpenseModel> expenseList;

        [ObservableProperty]
        public List<string> expenseTitleList;

        [ObservableProperty]
        public List<string> expenseAmountList;

        [ObservableProperty]
        public string totalExpenseAmount;

        [ObservableProperty]
        public string expenseListFetchError;

        public INavigation Navigation { get; set; }
        public ExpenseListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ExpenseTitleList = new List<string>();
            ExpenseAmountList = new List<string>();
            expenseList = Query.GetAllExpenses();
            CreateLists();
        }

        [RelayCommand]
        public async void Add(EventArgs e)
        {
            Dictionary<string, object> addExpensePageNavigationParameter = new Dictionary<string, object>
            {
                {nameof(AddExpensePage), typeof(AddExpensePage) }
            };
            await Shell.Current.GoToAsync(nameof(AddExpensePage), addExpensePageNavigationParameter);
        }

        [RelayCommand]
        public async void ExpenseTapped(string specificExpenseTitle)
        {
            await Navigation.PushAsync(new ExpenseDetailPage(specificExpenseTitle));
        }

        void CreateLists()
        {
            decimal totalExpense = 0;

            foreach (ExpenseModel expense in expenseList)
            {
                try
                {
                    totalExpense +=expense.ExpenseAmount;
                    ExpenseTitleList.Add(Convert.ToString(expense.ExpenseTitle));
                    ExpenseAmountList.Add("Rs "+Convert.ToString(expense.ExpenseAmount));
                }
                catch (Exception e)
                {
                    ExpenseListFetchError = e.Message;
                }
            }

            TotalExpenseAmount = "Rs " + Convert.ToString(totalExpense);
        }
    }
}
