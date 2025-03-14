using System;
/**
Encapsulation is sometimes referred to as the first pillar or principle of object-oriented programming. 
A class or struct can specify how accessible each of its members is to code outside of the class or struct. 
Methods and variables that aren't intended to be used from outside of the class or assembly can be hidden to limit the potential for coding errors or malicious exploits.

Encapsulation is a fundamental concept in Object-Oriented Programming (OOP) that helps in protecting the internal state of an object and only exposing a controlled interface to the outside world.

Feature Involes to Acheive Encapsulation :
1. Access modifier
2. Properties
3. Methods
4. Field and Data Validation.


Advantages of Encapsulation in C#:
Data protection: You can validate the data before storing it in the variable.
Achieving Data Hiding: The user will have no idea about the inner implementation of the class.
Security: The encapsulation Principle helps to secure our code since it ensures that other units(classes, interfaces, etc) can not access the data directly.
Flexibility: The encapsulation Principle in C# makes our code more flexible, allowing the programmer to easily change or update the code.
Control: The encapsulation Principle gives more control over the data stored in the variables. For example, we can control the data by validating whether the data is good enough to store in the variable.


Simple word about Encapsulation:
Bundle up all variable or properties and methods to operate with data in variables related to Single unit.

By doing this we acheive Encapsulation:
Modularity - splited small unit from complex model.
control access - by access specifiers we controled to access the member of object / who to access .
Internal state of data is hidden from one object to other object,types.
**/
namespace Encapsulation{
    public class BankAccount
    {
        // Private field to store the balance
        private decimal balance;

        // Public property to get the balance (read-only)
        public decimal Balance
        {
            get { return balance; }
        }

        // Public property with validation to set the account holder's name
        private string accountHolderName;
        public string AccountHolderName
        {
            get { return accountHolderName; }
            set
            {
                //Encapsulation in Data Validation 
                if (!string.IsNullOrWhiteSpace(value))
                {
                    accountHolderName = value;
                }
                else
                {
                    Console.WriteLine("Account holder name cannot be empty.");
                }
            }
        }

        // Constructor to initialize the account with a holder's name and initial balance
        public BankAccount(string name, decimal initialBalance)
        {
            AccountHolderName = name;
            Deposit(initialBalance); // Using the Deposit method to ensure validation
        }

        // Public method to deposit money into the account with validation
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        // Public method to withdraw money from the account with validation
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
        }
    }

    class Encapsulation{
        public static void Main(){
            Console.WriteLine("Encapsulation");
            BankAccount customer1 = new BankAccount("navaneethan",500);
            BankAccount customer2 = new BankAccount("nickil", 10000);
            Console.WriteLine("customer1 Balance :" + customer1.Balance);
            Console.WriteLine("customer2 Balance :" + customer2.Balance);
            //customer1.balance = 100000; - Error we restricted access to balance varibale - Encapsulation
            //allow access to member of object only public, internal or protected or protected internal.

            customer1.Deposit(10000);
            Console.WriteLine("customer1 Current Balance :" + customer1.Balance);
            customer2.Withdraw(500);
            Console.WriteLine("customer2 Current Balance :" + customer2.Balance);

            customer1.AccountHolderName = "Navaneethan S";
            Console.WriteLine(customer1.AccountHolderName);
        }
    }
}