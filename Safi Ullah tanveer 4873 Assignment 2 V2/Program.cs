using System;
using System.Collections.Generic;

namespace Safi_Ullah_tanveer_4873_Assignment_2_V2
{
    public interface IBankAccount
    {

        void deposit(double deposited);
        void withdraw(double withdrawl_amount);

    }

    public abstract class BankAccount : IBankAccount
    {
        protected string Account_Holder_name;
        public string AccountHolder_name { get; set; }

        protected int accountNumber;
        public int Account_number { get; set; }

        protected double Balance;
        public double balance { get; set; }


        public BankAccount()
        {

        }

        public BankAccount(string person_name, int acc_num, double bal)
        {
            Account_Holder_name = person_name;
            Account_number = acc_num;
            Balance = bal;
        }

        public abstract void deposit(double deposited);


        public abstract void withdraw(double withdrawl_amount);


        public abstract void DisplayAccountInfo();



    }

    public class SavingsAccount : BankAccount, IBankAccount
    {
        public double my_Interest_Rate;
        public int my_time = 0;

        public SavingsAccount(string person_name, int acc_num, double bal, double Interest_Rate, int time) : base(
            person_name, acc_num, bal)
        {
            my_Interest_Rate = Interest_Rate;
            my_time = time;

        }

        public override void deposit(double deposited)
        {
            // base.Deposit(deposit);
            Console.WriteLine("\tSAVING ACCOUNTS DEPOSIT FUNCTION.");
            Console.WriteLine("Amount for deposit is : " + deposited);
            Console.WriteLine("Balance before from account holder " + Account_Holder_name + " deposit is : " + Balance);
            Balance += deposited * my_Interest_Rate * my_time;
            Console.WriteLine("Balance after from account holder " + Account_Holder_name + " deposit is : " + Balance);
        }

        public override void withdraw(double withdrawl_amount)
        {
            Console.WriteLine("\tSAVING ACCOUNTS WITHDRAW FUNCTION.");
            double balance = 1000;
            if (withdrawl_amount < balance)
            {
                balance -= withdrawl_amount;
                Console.WriteLine("aBalance in account after withdrawl is:" + balance);
            }
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine(Account_Holder_name);
            Console.WriteLine(Account_number);
            Console.WriteLine(Balance);
        }

    }

    public class Checking_Account : BankAccount, IBankAccount
    {

        public Checking_Account(string person_name, int acc_num, double bal) : base(person_name, acc_num, bal)
        {

        }

        public override void deposit(double deposited)
        {
            Console.WriteLine("\tCHECKING ACCOUNTS DEPOSIT FUNCTION.");
            Console.WriteLine("Amount for deposit is : " + deposited);
            Console.WriteLine("Balance before from account holder " + Account_Holder_name + " deposit is : " + Balance);
            Balance += deposited;
            Console.WriteLine("Balance after from account holder " + Account_Holder_name + "deposut is " + Balance);
        }

        public override void withdraw(double withdrawl_amount)
        {
            Console.WriteLine("\tCHECKING ACCOUNTS WITHDRAW FUNCTION.");
            if (withdrawl_amount <= Balance)
            {
                Console.WriteLine("Amount to withdrawn is : " + withdrawl_amount);
                Console.WriteLine("Balance before from account holder " + Account_Holder_name + " withdraw is : " +
                                  Balance);
                Balance -= withdrawl_amount;
                Console.WriteLine("Balance after from account holder " + Account_Holder_name + " withdraw is : " +
                                  Balance);
                DisplayAccountInfo();
            }
            else
            {
                Console.WriteLine("You don't have sufficient amount");
                DisplayAccountInfo();
            }
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine(Account_Holder_name);
            Console.WriteLine(Account_number);
            Console.WriteLine(Balance);
        }
    }

    public class Bank
    {
        public List<BankAccount> BankAccounts { get; set; }

        public Bank()
        {
            BankAccounts = new List<BankAccount>();
        }

        public void Add_Account()
        {
            Console.WriteLine("Enter the account holder name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the account number : ");
            int acc_num = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the initial balance : ");
            double balance = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the account type. \n Enter 1 for saving account and 0 for checking account :");
            int type = int.Parse(Console.ReadLine());
            if (type == 1)
            {
                Console.WriteLine("Enter the interest rate : ");
                double interest = double.Parse(Console.ReadLine());
                Console.WriteLine("Give the time of interest deposits:");
                int time = int.Parse(Console.ReadLine());
                BankAccount accounts = new SavingsAccount(name, acc_num, balance, interest, time);
                BankAccounts.Add(accounts);
            }

            if (type == 0)
            {
                BankAccount accounts = new Checking_Account(name, acc_num, balance);
                BankAccounts.Add(accounts);
            }

        }







        public void deposit(double deposited)
        {
            Console.WriteLine("Give the Account Number for deposits:");
            int acc = int.Parse(Console.ReadLine());
            int i;
            for (i = 0; i < BankAccounts.Count; i++)
            {
                if (acc == BankAccounts[i].Account_number)
                {
                    // Console.WriteLine("Enter the amount for deposit : ");
                    // double amount = double.Parse(Console.ReadLine());
                    BankAccounts[i].deposit(deposited);
                }

            }
        }

        public void withdraw(double withdrawl_amount)
        {
            Console.WriteLine("Give the Account Number for withdrawl:");
            int acc = int.Parse(Console.ReadLine());
            int i;
            for (i = 0; i < BankAccounts.Count; i++)
            {
                if (acc == BankAccounts[i].Account_number)
                {
                    // Console.WriteLine("Enter the amount for deposit : ");
                    // double amount = double.Parse(Console.ReadLine());
                    BankAccounts[i].withdraw(withdrawl_amount);
                }

            }
        }
    }


    internal class Program
    {
        public static void Main(string[] args)
        {
            Bank bank2 = new Bank();
            bank2.Add_Account();
            bank2.Add_Account();
            // Console.WriteLine("Enter value to deposit : ");
            int bal = 2000;
            bank2.withdraw(bal);

            // Console.WriteLine("Enter value to withdraw : ");
            int amount = 100;
            bank2.withdraw(amount);
        }
    }
}
