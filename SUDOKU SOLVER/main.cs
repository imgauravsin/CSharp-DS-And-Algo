using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukoSolver
{
    class Program
    {
        static void Display(int[,] grid)
        {
 
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                }

                Console.WriteLine();
            }

         }
        static bool IsItSafe(int[,] grid, int row, int col, int target)
        {
            // row
            for (int c = 0; c < grid.GetLength(1); c++)
            {
                if (grid[row, c] == target)
                    return false;
            }

            // col
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                if (grid[r, col] == target)
                    return false;
            }

            // 3*3 grid
            int a = row / 3;
            int b = col / 3;
            a = a * 3;
            b = b * 3;
            for (int i = a; i < a + 3; i++)
            {
                for (int j = b; j < b + 3; j++)
                {
                    if (grid[i,j] == target) return false;
                }
            }
            return true;
            

        }
        static void Sudoku(int[,] grid, int cr, int cc, int er, int ec)
        {

            if (cr > er)
            {
                Display(grid);
                return;
            }

            if (cc > ec)
            {
                Sudoku(grid, cr + 1, 0, er, ec);
                return;
            }

            if (grid[cr, cc] != 0)
            {
                Sudoku(grid, cr, cc + 1, er, ec);
                return;
            }

            for (int i = 1; i <= 9; i++)
            {
                if (IsItSafe(grid, cr, cc, i))
                {
                    grid[cr, cc] = i;
                    Sudoku(grid, cr, cc + 1, er, ec);
                    grid[cr, cc] = 0;
                }
            }


        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] input=new string[n];
            int[,] grid = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                input[i] = Console.ReadLine();
                string[] splittedInput = input[i].Split(' ');
                for(int j = 0; j < splittedInput.Length; j++)
                {
                    grid[i,j]=Convert.ToInt32(splittedInput[j]);
                }
                

            }
           
            Sudoku(grid, 0, 0, n-1, n-1);
            //Display(grid);7
            Console.ReadLine();
        }
    }
}
