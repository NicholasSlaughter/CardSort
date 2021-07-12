using System;

namespace CardSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper h = new Helper();
            string continu = "a";
            string response;

            //The program will continue to run untill the user wants to end the program
            while (continu[0] != 'n')
            {
                h.Play(); //Execute the card sort functionality

                //Check to see if the user wants to sort another deck of cards
                response = "a";
                while (response != "g")
                {
                    Console.Write("Would you like to sort another deck of cards? (Y/N): ");
                    response = Console.ReadLine().ToLower();
                    if (response[0] == 'y' || response[0] == 'n')
                    {
                        //If the user input a valid response then set continue to either y or n and exit the nested while loop
                        continu = response;
                        response = "g";
                        if(continu[0] == 'y')
                            Console.WriteLine(""); //Seperates previous card sorts by a new line space
                    }
                    else
                        Console.WriteLine("ERROR: You can only enter Y or N for your response!"); //If the user input any other string that does not start with y or n then tell the user and prompt them to enter an answer again
                }
            }
        }
    }
}
