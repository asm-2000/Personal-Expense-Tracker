using ExpenseTracker.Pages;

namespace ExpenseTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ExpenseListPage), typeof(ExpenseListPage));
            Routing.RegisterRoute(nameof(AddExpensePage), typeof(AddExpensePage));
            Routing.RegisterRoute(nameof(ExpenseDetailPage), typeof(ExpenseDetailPage));
        }
    }
}
