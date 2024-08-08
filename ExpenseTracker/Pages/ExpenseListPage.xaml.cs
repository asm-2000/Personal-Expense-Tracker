using ExpenseTracker.ViewModels;

namespace ExpenseTracker.Pages;

public partial class ExpenseListPage : ContentPage
{
	public ExpenseListPage()
	{
		InitializeComponent();
		BindingContext = new ExpenseListViewModel(Navigation);
	}
}