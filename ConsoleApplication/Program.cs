using DataApp.Core.Controllers;
using DataApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApp.Core;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAppFacade db = new DataAppFacade();

            //controller.Add(new Check() { Notes = "xxx", Amount = 1, AddedOn = System.DateTime.Now, TransactionAccountId = 1 });

            Console.WriteLine("==========================================");
            Console.WriteLine("Checks:");
            foreach (var item in db.CheckController.GetAll())
            {
                Console.WriteLine(item.Notes);
                Console.WriteLine("checktransactions:");
                foreach (var checktransactions in item.CheckTransactions)
                {
                    Console.WriteLine( ">>>> {0}" ,checktransactions.Amount);    
                }

            }

            Console.WriteLine("==========================================");
            Console.WriteLine("Vouchers:");
            foreach (var item in db.VoucherController.GetAll())
            {
                Console.WriteLine(item.Notes);
                Console.WriteLine("Expenses:");
                foreach (var expenses in item.Expenses)
                {
                    Console.WriteLine(">>>> {0}", expenses.Id);
                }
                Console.WriteLine("Check transactions:");
                foreach (var expenses in item.CheckTransactions)
                {
                    Console.WriteLine(">>>> {0}", expenses.Id);
                }
            }

            Console.ReadLine();
        }
    }
}
