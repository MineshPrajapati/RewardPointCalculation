using System;
using System.Collections.Generic;
using static RewardPointCalculation.Model;



public class Program
{
    public static void Main(string[] args)
    {
        // Sample customer data
        var customers = new List<Customer>()
        {
            new Customer
            {
                Name = "John Doe",
                Transactions = new List<Transaction>()
                {
                    new Transaction { Date = new DateTime(2023, 12, 01), Amount = 110 },
                    new Transaction { Date = new DateTime(2024, 01, 15), Amount = 80 },
                    new Transaction { Date = new DateTime(2024, 02, 10), Amount = 150 },
                }
            },
            new Customer
            {
                Name = "Jane Smith",
                Transactions = new List<Transaction>()
                {
                    new Transaction { Date = new DateTime(2023, 12, 05), Amount = 75 },
                    new Transaction { Date = new DateTime(2024, 01, 20), Amount = 125 },
                    new Transaction { Date = new DateTime(2024, 02, 05), Amount = 60 },
                }
            },
        };

        // Calculate and print the reward points
        foreach (var customer in customers)
        {
            Console.WriteLine($"Customer: {customer.Name}");
            Console.WriteLine("Monthly Points:");
            var monthlyPoints = CalculateMonthlyPoints(customer.Transactions);
            foreach (var month in monthlyPoints)
            {
                Console.WriteLine($"\tMonth {month.Month}: {month.Points}");
            }
            Console.WriteLine($"Total Points: {CalculateTotalPoints(customer.Transactions)}");
        }
    }

    private static List<MonthPoints> CalculateMonthlyPoints(List<Transaction> transactions)
    {
        var monthlyPoints = new List<MonthPoints>();
        foreach (var transaction in transactions)
        {
            var points = CalculateRewardPoints(transaction.Amount);
            var month = transaction.Date.Month;

            var existingMonth = monthlyPoints.FirstOrDefault(m => m.Month == month);
            if (existingMonth != null)
            {
                existingMonth.Points += points;
            }
            else
            {
                monthlyPoints.Add(new MonthPoints { Month = month, Points = points });
            }
        }
        return monthlyPoints;
    }

    private static int CalculateTotalPoints(List<Transaction> transactions)
    {
        return transactions.Sum(t => CalculateRewardPoints(t.Amount));
    }

    private static int CalculateRewardPoints(double amount)
    {
        
        var points = 0;
        if (amount > 100) //For Amount greater than 100
        {
            points += (int)(amount - 100) * 2;
        }
        if (amount > 50) //for Amount greater 50
        {
            points += (int)(amount - 50) * 1;
        }
        return points;
    }
}

