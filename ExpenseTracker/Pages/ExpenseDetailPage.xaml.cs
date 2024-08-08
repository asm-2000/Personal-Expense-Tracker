namespace ExpenseTracker.Pages;
using ExpenseTracker.ViewModels;
public partial class ExpenseDetailPage : ContentPage
{
	public ExpenseDetailPage(string specificExpenseTitle)
	{
		InitializeComponent();
		BindingContext = new ExpenseDetailViewModel(specificExpenseTitle);
	}
}