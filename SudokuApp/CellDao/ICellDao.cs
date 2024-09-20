using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.SudokuApp.Model.CellDao
{
    public interface ICellDao : IGenericDao<Cell, Int64>
    {
        void addCellsAndImageToSudokuPuzzle(Sudoku sudoku, int[,] puzzle, int[,] image);

        void addCellsAndImageToSudokuSolution(Sudoku sudoku, int[,] solution, int[,] image);


        int[,] getSudokuCellPuzzle(Sudoku sudoku);

        int[,] getSudokuCellSolution(Sudoku sudoku);

        int[,] getSudokuCellImage(Sudoku sudoku);

        void updateCellsPuzzle(Sudoku sudoku, int[,] puzzle);
        void updateCellsSolution(Sudoku sudoku, int[,] solution);


        long getCellIdByPosition(Sudoku sudoku, (int,int) pos);

        Cell getCellByPosition(Sudoku sudoku, (int, int) pos);

    }
}
