using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.SudokuApp.Model.SudokuDao;
using Ninject;

namespace Es.Udc.DotNet.SudokuApp.Model.CellDao
{
    public class CellDaoEntityFramework : GenericDaoEntityFramework<Cell, Int64>, ICellDao
    {
        [Inject]
        public ISudokuDao sudokuDao { private get; set; }
        public CellDaoEntityFramework()
        {
        }

        public void addCellsAndImageToSudokuPuzzle(Sudoku sudoku, int[,] puzzle, int[,] image)
        {
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    Cell cell = new Cell();
                    cell.cell_value = puzzle[i,j];
                    cell.col_index = i+1;
                    cell.row_index = j+1;
                    cell.image = image[i, j];
                    base.Create(cell);
                    sudoku.Cell1.Add(cell);
                    sudokuDao.Update(sudoku);
                }
            }
        }

        public void addCellsAndImageToSudokuSolution(Sudoku sudoku, int[,] solution, int[,] image)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cell cell = new Cell();
                    cell.cell_value = solution[i,j];
                    cell.image = image[i, j];
                    cell.col_index = i+1;
                    cell.row_index = j+1;
                    base.Create(cell);
                    sudoku.Cell.Add(cell);
                    sudokuDao.Update(sudoku);
                }
            }
        }


        public void updateCellsPuzzle(Sudoku sudoku, int[,] puzzle)
        {
            List<Cell> cells = sudoku.Cell1.ToList();
            List<Cell> newCells = new List<Cell>();


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cell cell = new Cell();
                    cell.cell_value = puzzle[i, j];
                    cell.col_index = i + 1;
                    cell.row_index = j + 1;
                    newCells.Add(cell);
                }
            }

        }

        public int[,] getSudokuCellPuzzle(Sudoku sudoku)
        {
            List<Cell> cells = sudoku.Cell1.ToList();
            int[,] result = new int[9,9];


            foreach (Cell i in cells) {
                result[(int)i.col_index-1, (int)i.row_index - 1] = (int)i.cell_value;  
            }

            return result;
        }

        public int[,] getSudokuCellSolution(Sudoku sudoku)
        {
            List<Cell> cells = sudoku.Cell.ToList();
            int[,] result = new int[10, 10];


            foreach (Cell i in cells)
            {
                result[(int)i.col_index-1, (int)i.row_index - 1] = (int)i.cell_value;
            }

            return result;
        }

        public int[,] getSudokuCellImage(Sudoku sudoku)
        {
            List<Cell> cells = sudoku.Cell.ToList();
            int[,] result = new int[10, 10];

            foreach (Cell i in cells)
            {
                result[(int)i.col_index - 1, (int)i.row_index - 1] = (int)i.image;
            }

            return result;
        }


        public void updateCellsSolution(Sudoku sudoku, int[,] solution)
        {
            throw new NotImplementedException();
        }

        public long getCellIdByPosition(Sudoku sudoku, (int,int) pos)
        {
            List<Cell> cells = sudoku.Cell1.ToList();
            int absolutePosition = 0;

            if (pos.Item2-1 != 0) {
                absolutePosition = (pos.Item2-1) * 9;

            }
            absolutePosition += pos.Item1-1;


            return cells[absolutePosition].cellId;
        }

        public Cell getCellByPosition(Sudoku sudoku, (int, int) pos)
        {
            List<Cell> cells = sudoku.Cell1.ToList();
            int absolutePosition = 0;

            if (pos.Item2 - 1 != 0)
            {
                absolutePosition = (pos.Item2 - 1) * 9;

            }
            absolutePosition += pos.Item1 - 1;


            return cells[absolutePosition];
        }


    }
}
