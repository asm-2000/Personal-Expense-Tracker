using Dapper;
using Npgsql;
using ExpenseTracker.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Data.Common;

namespace ExpenseTracker.Utilities
{
    public static class Query
    {
        public static IList<ExpenseModel> GetAllExpenses()
        {
            var connectionString = "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=ashim50;";
            IList<ExpenseModel> expenses = new ObservableCollection<ExpenseModel>();
            NpgsqlConnection Connection = new NpgsqlConnection(connectionString);

            using (Connection)
            {
                expenses = (IList<ExpenseModel>)Connection.Query<ExpenseModel>("Select * from expenses");
            }

            return expenses;
        }

        public static void StoreExpense(ExpenseModel newExpense)
        {
            var connectionString = "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=ashim50;";
            NpgsqlConnection Connection = new NpgsqlConnection(connectionString);

            using (Connection)
            {

                string insertQuery = "insert into expenses(ExpenseTitle, ExpenseDescription, ExpenseAmount) values (@ExpenseTitle, @ExpenseDescription, @ExpenseAmount)";
                {
                    Connection.Execute(insertQuery, new { newExpense.ExpenseTitle, newExpense.ExpenseDescription, newExpense.ExpenseAmount });
                }
            }
        }

        public static async Task<ExpenseModel> GetSpecificExpense(string expenseTitle) 
        {
            Debug.WriteLine(expenseTitle);
            var connectionString = "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=ashim50;";
            NpgsqlConnection Connection = new(connectionString);
            IList<ExpenseModel> expenseDetailList = [];

            await using (Connection)
            {
                string fetchSpecificExpenseQuery = "select * from expenses where ExpenseTitle = @expenseTitle";
                {
                    expenseDetailList =  (IList<ExpenseModel>)Connection.Query<ExpenseModel>(fetchSpecificExpenseQuery, new { expenseTitle });
                }
            }

            return expenseDetailList.FirstOrDefault();
        }

        public static void DeleteSpecificExpense(string expenseTitle)
        {
            var connectionString = "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=ashim50;";
            NpgsqlConnection Connection = new NpgsqlConnection(connectionString);

            using (Connection)
            {
                string deleteExpenseQuery = "delete from expenses where ExpenseTitle = @expenseTitle";
                {
                    Connection.Execute(deleteExpenseQuery, new { expenseTitle});
                }
            }
        }
    }
}
