using CommunityToolkit.Mvvm.ComponentModel;

namespace ExpenseTracker.Models
{
    public class ExpenseModel
    {
        public int ExpenseId { get; set; }
        public string ExpenseTitle { get; set; }
        public string ExpenseDescription { get; set; }
        public decimal ExpenseAmount { get; set; }

        public ExpenseModel(string expenseTitle, string expenseDescription, decimal expenseAmount)
        {
            ExpenseTitle = expenseTitle;
            ExpenseDescription = expenseDescription;
            ExpenseAmount = expenseAmount;
        }

        public ExpenseModel(int expenseId, string expenseTitle, string expenseDescription, decimal expenseAmount)
        {
            ExpenseId = expenseId;
            ExpenseTitle = expenseTitle;
            ExpenseDescription = expenseDescription;
            ExpenseAmount = expenseAmount;
        }

        public ExpenseModel() { }
    }
}
