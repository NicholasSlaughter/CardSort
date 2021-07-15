# CardSort
This program takes in a list of card values from a user and sorts these cards for the user.

Author: Nicholas Slaughter
Date Created: 7/12/2021
Date Last Modified: 7/15/2021
Purpose: Coding Challenge For Intel
Description: This program allows a user to input a deck of cards and have a sorted version of the deck of cards be output to the screen.
The deck of cards is sorted by suit first in the order of diamonds, spades, clubs, hearts and then by value from 2-Ace. The program only
allows the user to input a card as its numerical value followed by a single character representing the suit (i.e. 2d is the same as the 
2 of diamonds). If the user wants to have a face card in their deck of cards it must be represented as J, Q, K, or A (i.e. Jd is the same
as the Jack of diamonds). Once the users deck of cards has been sorted they will be asked if they would like to sort another deck of cards.
If the user enters 'Y' they will go again and if they enter 'N' the program will end.

Tests:
There are 45 tests for this program. All functionality of the program is tested within these 45 tests. All tests pass. Tests finish in about 43ms.

How To Run From Executable:
1. Open the Card Sort File
2. Open the next Card Sort File
3. Open bin
4. Open Debug
5. Open netcoreapp3.1
6. Open CardSort.exe
7. Enter cards by face value followed by suit and seperated by a comma
  a. Valid face values: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A
  b. Valid suit: d, s, c, h
  c. Example of valid card list: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h
8. Once you have typed all of your cards in, hit the enter key
9. You will then see the properly sorted output of your list of cards
  a. If you get an error you will be told what caused the error so you can easily fix it
10. You will then be asked if you would like to sort another list of cards
11. If you do want to sort another list then type Y if not then type N and hit enter
  a. If you do not enter Y or N an error will be displayed prompting you to choose Y or N again
12. If you entered Y then redo steps 7 - 11

How To Run From Visual Studio:
1. Open the Card Sort File
2. Open the CardSort.sln in Visual Studio
3. Build the application
4. Start debugging the application
6. Enter cards by face value followed by suit and seperated by a comma
  a. Valid face values: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A
  b. Valid suit: d, s, c, h
  c. Example of valid card list: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h
7. Once you have typed all of your cards in hit the enter key
8. You will then see the properly sorted output of your list of cards
  a. If you get an error you will be told what caused the error so you can easily fix it
9. You will then be asked if you would like to sort another list of cards
10. If you do want to sort another list then type Y if not then type N and hit enter
  a. If you do not enter Y or N an error will be displayed prompting you to choose Y or N again
11. If you entered Y then redo steps 6 - 10

How To Create and Run As Docker Image:
Note: You Must Have Docker Installed On Your System To Create and Run a Docker Image
1. Open the command line prompt window
2. Change your working directory to the second CardSort directory
    a. Example: cd C:\CardSort\CardSort
3. Execute the following command: docker build -t tag_name:v1 .
    a. tag_name can be whatever you want to call the image
4. Execute the following command to run the docker container:
    a. docker run -it --rm tag_name:v1
5. Enter cards by face value followed by suit and seperated by a comma
  a. Valid face values: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A
  b. Valid suit: d, s, c, h
  c. Example of valid card list: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h
6. Once you have typed all of your cards in hit the enter key
7. You will then see the properly sorted output of your list of cards
  a. If you get an error you will be told what caused the error so you can easily fix it
8. You will then be asked if you would like to sort another list of cards
9. If you do want to sort another list then type Y if not then type N and hit enter
  a. If you do not enter Y or N an error will be displayed prompting you to choose Y or N again
10. If you entered Y then redo steps 5 - 9
    
How To Run My Docker Image:
Note: You Must Have Docker Installed On Your System To Run My Docker Image
1. Open the command line prompt window
2. Change your working directory to the second CardSort directory
    a. Example: cd C:\CardSort\CardSort
3. Execute the following command to run the docker container:
    a. docker run -it --rm nicholasslaughter/card_sort:v3
4. Enter cards by face value followed by suit and seperated by a comma
  a. Valid face values: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A
  b. Valid suit: d, s, c, h
  c. Example of valid card list: 3c, Js, 2d, 10h, Kh, 8s, Ac, 4h
5. Once you have typed all of your cards in hit the enter key
6. You will then see the properly sorted output of your list of cards
  a. If you get an error you will be told what caused the error so you can easily fix it
7. You will then be asked if you would like to sort another list of cards
8. If you do want to sort another list then type Y if not then type N and hit enter
  a. If you do not enter Y or N an error will be displayed prompting you to choose Y or N again
9. If you entered Y then redo steps 4 - 8

Assumptions Made:
1. The user was to input their list of cards from the console window
  a. Otherwise the user would have to hard code a new list in the program everytime
2. The cards were not case sensitive so all values get converted to lowercase
  a. This means that jD would be a valid input as jack of diamonds.
  b. The output is still the specified output of Jd
  c. Makes the program easier to run tests on and makes the program more user friendly
3. Having the output of the cards be a new card on a new line was fine
  a. i.e. 
  Jd - Jack of Diamonds
  Kd - King of Diamonds
  3s - Three of Diamonds
  not Jd, Kd, 3s
  b. Makes the output easier to read
4. Adding the "CardValue of CardSuit" at the end of the output for a card was fine
  a. Jd - Jack of Diamonds
  b. Makes the output look better and easier to read
5. Adding xUnit tests was okay to do
6. Creating a dockerfile was okay to do

Bugs:
1. If there is multiple face cards with the same value all of those face cards will get converted into the same face card
