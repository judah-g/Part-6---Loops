using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_6___Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            string answer;

            double minimum = 0, maximum, guess;

            double bankAccount, transaction, heldMoney, bills;
            bool bankDone = false;
            Random random = new Random();

            int rolls = 0;
            Die die1 = new Die(1), die2 = new Die(2);

            while (!done)
            {
                Console.WriteLine("What do you want to access? \nP for prompter, B for banking, R for roller\n");
                answer = Console.ReadLine().ToLower();
                Console.Clear();

                if (answer == "p")
                {
                    Console.WriteLine("I'm gonna need a range \nGive me a minimum");

                    while (!double.TryParse(Console.ReadLine(), out minimum))
                        Console.WriteLine("That's not what I'm looking for"); 

                    maximum = minimum - 1;
                    Console.WriteLine("Now give me a maximum");
                    while (!double.TryParse(Console.ReadLine(), out maximum) || maximum <= minimum)
                        Console.WriteLine("That's not what I'm looking for");

                    Console.Clear();
                    Console.WriteLine($"Now I need a number between {minimum} and {maximum}");

                    guess = minimum - 1;
                    while (guess < minimum || guess > maximum)
                    {
                        if (!double.TryParse(Console.ReadLine(), out guess))
                        {
                            Console.WriteLine("That's not what I'm looking for");
                        }
                        else if (guess > minimum && guess < maximum)
                        {
                            Console.WriteLine("Thanks\n\n");
                        }
                        else
                        {
                            Console.WriteLine("I don't think that's in the range");
                            guess = minimum - 1;
                        }
                    }
                }

                else if (answer == "b")
                {
                    while (!bankDone)
                    {
                        bankAccount = 150;
                        heldMoney = 50;
                        bills = 10000;

                        Console.WriteLine("Welcome to the BoB\n\nYou will be charged $0.75 for anything.");
                        Console.WriteLine("D for deposit, W for withdrawal, P for payment, U for account update and Q to quit");
                        answer = Console.ReadLine().ToLower();

                        if (answer == "d")
                        {
                            Console.WriteLine("How much would you like to deposit?");
                            transaction = Convert.ToDouble(Console.ReadLine());
                            if (transaction < 0) { transaction *= -1; }

                            if (transaction > heldMoney)
                            {
                                Console.WriteLine($"Haha good one\n(You are only holding {heldMoney.ToString("C")})");
                                if (bankAccount > 0.75)
                                {
                                    bankAccount -= 0.75;
                                }
                            }
                            else if (bankAccount + transaction < 0.75)
                            {
                                Console.WriteLine($"Error {random.Next(1, 1000)}\nTransaction not accepted");
                                if (bankAccount > 0.75)
                                {
                                    bankAccount -= 0.75;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Transaction Successful");
                                bankAccount = bankAccount + transaction - 0.75;
                            }

                            System.Threading.Thread.Sleep(500);
                            Console.Clear();
                        }

                        else if (answer == "w")
                        {
                            Console.WriteLine("How much would you like to withdraw?");
                            transaction = Convert.ToDouble(Console.ReadLine());
                            if (transaction < 0) { transaction *= -1; }

                            if ((transaction + 0.75) > bankAccount)
                            {
                                Console.WriteLine($"Error {random.Next(1, 1000)}\nTransaction not accepted");
                                if (bankAccount > 0.75)
                                {
                                    bankAccount -= 0.75;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Transaction Successful");
                                bankAccount = bankAccount - (transaction + 0.75);
                                heldMoney += transaction;
                            }
                            System.Threading.Thread.Sleep(500);
                            Console.Clear();
                        }

                        else if (answer == "P")
                        {
                            Console.WriteLine($"You have {bills.ToString("C")} of bills");
                            Console.WriteLine("How much would you like to pay?");
                            transaction = Convert.ToDouble(Console.ReadLine());
                            if (transaction < 0) { transaction *= -1; }

                            if ((transaction + 0.75) > bankAccount)
                            {
                                Console.WriteLine($"Error {random.Next(1, 1000)}\nTransaction not accepted");
                                if (bankAccount > 0.75)
                                {
                                    bankAccount -= 0.75;
                                }
                            }
                            else
                            {
                                bills -= transaction;
                                bankAccount -= 0.75;

                                Console.WriteLine($"Transaction Successful\nYou have {bills.ToString("C")} of bills remaining.");
                            }
                            System.Threading.Thread.Sleep(500);
                            Console.Clear();
                        }

                        else if (answer == "u")
                        {

                            if (bankAccount > 0.75)
                            {
                                bankAccount -= 0.75;
                                Console.WriteLine($"You have {bankAccount.ToString("C")} in your account");
                            }
                        }

                        else if (answer == "q")
                        {
                            Console.WriteLine("Are you sure you want to quit?\nYou will lose all progress? (Y or N)");
                            answer = Console.ReadLine().ToLower();

                            if (answer == "y")
                            { bankDone = true; }
                            System.Threading.Thread.Sleep(500);
                            Console.Clear();
                        }

                        else
                        {
                            Console.WriteLine($"Error {random.Next(1, 1000)}\nCommand not accepted");
                            if (bankAccount > 0.75)
                            {
                                bankAccount -= 0.75;
                            }
                        }
                    }
                }

                else if (answer == "r") 
                {
                    Console.WriteLine("I'm not gonna stop rolling until I get doubles");
                    System.Threading.Thread.Sleep(400);

                    while (die1.Roll != die2.Roll)
                    {
                        die1.RollDie(); die2.RollDie(); die2.RollDie();
                        die1.DrawDie(); die2.DrawDie();
                        rolls++;

                        if (die1.Roll == die2.Roll)
                        {
                            Console.WriteLine($"I got it! It took me {rolls} rolls");
                        }
                        else
                        {
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                        }
                    }
                }

                else if (answer == "d")
                {
                    done = true;
                }

                else
                {
                    Console.WriteLine("I don't have that command");
                }
            }
        }
    }
}
