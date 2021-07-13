using System;

/// <summary>
/// Author: Nicholas Slaughter
///Date Created: 7/12/2021
///Date Last Modified: 7/12/2021
///Purpose: Coding Challenge For Intel
///Description: This program allows a user to input a deck of cards and have a sorted version of the deck of cards be output to the screen.
///The deck of cards is sorted by suit first in the order of diamonds, spades, clubs, hearts and then by value from 2-Ace. The program only
///allows the user to input a card as its numerical value followed by a single character representing the suit (i.e. 2d is the same as the 
///2 of diamonds). If the user wants to have a face card in their deck of cards it must be represented as J, Q, K, or A (i.e. Jd is the same
///as the Jack of diamonds). Once the users deck of cards has been sorted they will be asked if they would like to sort another deck of cards.
///If the user enters 'Y' they will go again and if they enter 'N' the program will end.
/// </summary>

namespace CardSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper h = new Helper();
            h.Play();
            Console.WriteLine("Goodbye");
        }
    }
}