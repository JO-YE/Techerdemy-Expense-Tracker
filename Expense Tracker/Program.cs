// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

class Program
{
    static List<Expense> expenses = new List<Expense>();

    static void Main()
    {
        bool IsRunning = true;

        while(IsRunning)
        {
            Console.WriteLine("\n Expense Tracker");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. View Total Expense");
            Console.WriteLine("6. Exit App");
            Console.WriteLine("Enter your choice: ");
           
            if(!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            switch (choice)
            {
                case 1:
                    AddExpense();
                    break;
                case 2:
                    DisplayExpenses();
                    break;
                case 3:
                    UpdateExpense();
                    break;
                case 4:
                    RemoveExpense();
                    break;
                case 5:
                    TotalExpense();
                    break;
                case 6:
                    IsRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid Choice. Please try again.");
                    break;
            }
        }
    }

    static void AddExpense()
    {
        Console.WriteLine("\nEnter product name:");
        string? productname = Console.ReadLine();

        Console.WriteLine("\nEnter Amount(N):");
        // ensuring that it is a number that was passed and also the amount is not less than zero
        if(!int.TryParse(Console.ReadLine(), out int amount) || amount < 0)
        {
            Console.WriteLine("Invalid amount. Please enter a valid number");
        }
        else
        {
            expenses.Add(new Expense { ProductName = productname, Amount = amount });
            Console.WriteLine("Expense added Successfully");
        }
       // we could use return method, just like it was done in UpdateExpense 

    }

    static void DisplayExpenses()
    {
        if(expenses.Count==0)
        {
            Console.WriteLine("\nNo expenses recorded yet.");
            return;
        }
        Console.WriteLine("\nExpenses recorded include: ");
        foreach(Expense expense in expenses)
        {
            Console.WriteLine($"{expense.ProductName} - N{expense.Amount}");
        }

    }

    static void UpdateExpense()
    {
        Console.WriteLine("\nEnter the product name you would like to update");
        string? productname = Console.ReadLine();

        Expense? product = expenses.Find(e => e.ProductName == productname);

        if(product == null)
        {
            Console.WriteLine($"{productname} not found.");
            return;
        }
        Console.WriteLine("\nEnter updated price/amount");
        if (!int.TryParse(Console.ReadLine(), out int amount) || amount < 0)
        {
            Console.WriteLine("Invalid amount. Please enter a valid number");
            return;
        }
        product.Amount = amount;
        Console.WriteLine("Product price updated successfully");
        
        
    }

    static void RemoveExpense()
    {
        Console.WriteLine("\nEnter the product name you would like to remove");
        string? productname = Console.ReadLine();

        Expense? product = expenses.Find(e => e.ProductName == productname);

        if (product == null)
        {
            Console.WriteLine($"{productname} not found.");
            return;
        }
        expenses.Remove(product);
        Console.WriteLine("Product removed successfully");

        TotalExpense();
    }

    static void TotalExpense()
    {
        int total = expenses.Sum(e => e.Amount);
        Console.WriteLine($"\nTotal Amount Spent: N{total}");
    }
}
class Expense
{
    public string? ProductName { get; set; }
    public int Amount { get; set; }
}