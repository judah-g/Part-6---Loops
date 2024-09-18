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
            bool done = false, bankDone = false;
            string answer;
            double minimum = 0, maximum, guess, bankAccount;

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
                        if (double.TryParse(Console.ReadLine(), out guess) == false)
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

                        Console.WriteLine("Welcome to the BoB\n\nYou will be charged $0.75 for anything.");
                        Console.WriteLine("D for deposit, W for withdrawal, P for payment, U for account update and Q to quit");
                    }
                }
            }
        }
    }
}
