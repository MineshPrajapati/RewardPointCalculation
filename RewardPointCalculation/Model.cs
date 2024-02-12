using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RewardPointCalculation
{
    internal class Model
    {
        public class Customer
        {
            public string Name { get; set; }
            public List<Transaction> Transactions { get; set; }
        }

        public class Transaction
        {
            public DateTime Date { get; set; }
            public double Amount { get; set; }
        }
        public class MonthPoints
        {
            public int Month { get; set; }
            public int Points { get; set; }
        }
    }
}
