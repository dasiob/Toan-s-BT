/*
*
*   Step 1: Place a move
*   Step 2: Check if move is legal or not
*       Case false => back to step 1
*       Case true => step 3
*   Step 3: check win
*       Case false => change player => back to step 1
*       Case true => end game 
*
*/

using System;

namespace Main
{
    class Program {
        static List<int> winningCombination1 = new List<int> {0 , 1, 2};
        static List<int> winningCombination2 = new List<int> {3 , 4, 5};
        static List<int> winningCombination3 = new List<int> {6 , 7, 8};
        static List<int> winningCombination4 = new List<int> {0 , 3, 6};
        static List<int> winningCombination5 = new List<int> {1 , 4, 7};
        static List<int> winningCombination6 = new List<int> {2 , 5, 8};
        static List<int> winningCombination7 = new List<int> {0 , 4, 8};
        static List<int> winningCombination8 = new List<int> {2 , 4, 6};

        static List<List<int>> winningCombinations = new List<List<int>>();

        //add all winning combinations to a list to check easier later
        public Program() {
            winningCombinations.Add(winningCombination1);
            winningCombinations.Add(winningCombination2);
            winningCombinations.Add(winningCombination3);
            winningCombinations.Add(winningCombination4);
            winningCombinations.Add(winningCombination5);
            winningCombinations.Add(winningCombination6);
            winningCombinations.Add(winningCombination7);
            winningCombinations.Add(winningCombination8);
        }

        static void Main(string[] args)
        {
            //invoke program class constructor to run all code inside constructor
            new Program();
            bool turnX = false;
            int[] board = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0};

            System.Console.WriteLine("");
            printBoard(board);
            int turnCount = 0;
            while(turnCount < 9) {
                //Change player
                turnX = !turnX;
                System.Console.WriteLine("\n-------------\n");
                //Step 1
                bool legal = true;
                int cellChose = 0;
                //Step 2: if ilegal then loop to place move again
                while (legal) {
                    System.Console.Write("Your move: ");
                    cellChose = int.Parse(Console.ReadLine());
                    if (!checkIsLegalMove(board, cellChose)) System.Console.WriteLine("\nYour move is illegal! Please choose again\n");
                    else legal = false;
                }
                board = placeMove(cellChose, turnX, board);
                turnCount++;
                printBoard(board);
                //Step 3
                int cellValue = turnX ? 1 : 2;
                if (checkWin(board, cellValue)) {
                    System.Console.WriteLine("\n******************");
                    System.Console.WriteLine("* Congrats to " + (turnX ? "X! *" : "O! *"));
                    System.Console.WriteLine("******************\n");
                    break;
                }
                if (turnCount == 9) {
                    System.Console.WriteLine("\n******************");
                    System.Console.WriteLine("*      Draw!     *");
                    System.Console.WriteLine("******************\n");
                }
            }
        }

        public static bool checkWin(int[] board, int cellValue) {
            bool win = false;
            //using for each to check each combination
            foreach (List<int> winCombination in Program.winningCombinations)
            {
                int count = 0;
                //again for each to check if all cell in a combination equal to 1 value
                //Ex: 0 | 1 | 0
                //    0 | 1 | 0
                //    0 | 1 | 0
                //board[cell] of combination {1, 4, 7} all equals to 1 -> X win (1 = X, 2 = O, 0 = empty)
                winCombination.ForEach(cell => {
                    if (board[cell] == cellValue) count++;
                });
                if (count == 3) win = true;
            }
            return win;
        }

        public static void printBoard(int[] board) {
            for (var i = 0; i < 9; i++) {
                System.Console.Write("| ");
                if (board[i] == 0) System.Console.Write("  ");
                else if (board[i] == 1) System.Console.Write("X ");
                else System.Console.Write("O ");
                if ((i + 1) % 3 == 0) {
                    System.Console.WriteLine("|");
                }
            }
        }

        //if cell of array = 0 -> empty cell | = 1 -> x played | = 2 -> o played
        public static int[] placeMove(int cell, bool turnX, int[] board) {
            if (turnX) board[cell] = 1;
            else board[cell] = 2;
            return board;
        }

        //check if cell of array = 0 -> empty cell
        public static bool checkIsLegalMove(int [] board, int cell) {
            if (board[cell] != 0) return false;
            return true;
        }
    }
}