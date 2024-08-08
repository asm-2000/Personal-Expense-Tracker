namespace ExpenseTracker.Pages;
using ExpenseTracker.ViewModels;
public partial class AddExpensePage : ContentPage
{
	public AddExpensePage()
	{
		InitializeComponent();
		BindingContext = new AddExpenseViewModel();
	}
}