using ProjectEuler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class NinetySix
    {
        private static readonly int dimension = 9;

        public static long Go()
        {
            var puzzles = GetPuzzles(Helpers.GetPuzzlesFor96());

            foreach (var puzzle in puzzles.GetRange(0, 1))
            {
                Solve(puzzle, 0);
            }
            return 0;
        }

        private static void Solve(Sudoku puzzle, int slot)
        {
            var slotValue = 1;
            while (slot < Math.Pow(dimension, 2))
            {
                var result = AttemptSolution(slotValue, slot, puzzle);
                if (result)
                {
                    slot = GetNextOpenSlot(puzzle, slot);
                    slotValue = 1;
                }
                else
                {
                    slot--;
                    slotValue = GetValueFromSlot(slot, puzzle) + 1;
                }
            }
        }

        private static int GetValueFromSlot(int slot, Sudoku puzzle)
        {
            var row = slot / dimension;
            var cell = slot % dimension;
            return puzzle.Grid[row][cell];
        }

        private static bool AttemptSolution(int slotValue, int slot, Sudoku puzzle)
        {
            
            var row = slot / dimension;
            var cell = slot % dimension;

            while (!NumberOKForSlot(slotValue, slot, puzzle))
            {
                slotValue++;
            }

            if (slotValue <= dimension)
            {
                puzzle.Grid[row][cell] = slotValue;
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool NumberOKForSlot(int slotValue, int slot, Sudoku puzzle)
        {
            if (slotValue > dimension) return false;

            var rowNumber = slot / dimension;
            var columnNumber = slot % dimension;
            var rowOK = NumberOKForRow(slotValue, rowNumber, puzzle);
            var columnOK = NumberOKForColumn(slotValue, columnNumber, puzzle);
            var smallSquareOK = NumberOKForSmallSquare(slotValue, slot, puzzle);

            return rowOK && columnOK && smallSquareOK;
        }

        private static bool NumberOKForRow(int slotValue, int rowNumber, Sudoku puzzle)
        {
            var row = puzzle.Grid[rowNumber];
            return !row.Any(x => x == slotValue);
        }

        private static bool NumberOKForColumn(int slotValue, int columnNumber, Sudoku puzzle)
        {
            var list = new List<int>();
            foreach(var gridRow in puzzle.Grid)
            {
                list.Add(gridRow[columnNumber]);
            }

            return !list.Any(x => x == slotValue);
        }

        private static bool NumberOKForSmallSquare(int slotValue, int slot, Sudoku puzzle)
        {
            var list = new List<int>();
            var row = slot / dimension;
            var cell = slot % dimension;
            var smallSquareRow = row / (dimension / 3);
            var smallSquareCol = slot % 3;

            for (var i = (row - smallSquareRow); i < (row - smallSquareRow + 3); i++)
            {
                for (var j = (smallSquareCol); j < (smallSquareCol + 3); j++)
                {
                    list.Add(puzzle.Grid[i][j]);
                }
            }

            return !list.Any(x => x == slotValue);
        }

        private static int GetNextOpenSlot(Sudoku puzzle, int slot)
        {
            var found = false;
            while (!found)
            {
                var row = slot / dimension;
                var cell = slot % dimension;
                if (puzzle.Grid[row][cell] == 0)
                {
                    slot = (row * dimension) + cell;
                    found = true;
                }
                else
                {
                    slot++;
                }
            }

            return slot;
        }

        private static List<Sudoku> GetPuzzles(string[] arr)
        {
            var list = new List<Sudoku>();
            foreach (var p in arr)
            {
                if (p != string.Empty)
                {
                    list.Add(new Sudoku(p));
                }
            }
            return list;
        }
    }
}
