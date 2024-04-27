using System;
using System.Collections.Generic;
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

        public void addCellsToSudokuPuzzle(Sudoku sudoku, int[,] puzzle)
        {
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    Cell cell = new Cell();
                    cell.cell_value = puzzle[i,j];
                    cell.col_index = i;
                    cell.row_index = j;
                    Create(cell);
                    sudoku.Cell.Add(cell);
                    sudokuDao.Update(sudoku);
                }
            }
        }

        public void addCellsToSudokuSolution(Sudoku sudoku, int[,] solution)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cell cell = new Cell();
                    cell.cell_value = solution[i,j];
                    cell.col_index = i;
                    cell.row_index = j;
                    Create(cell);
                    sudoku.Cell1.Add(cell);
                    sudokuDao.Update(sudoku);
                }
            }
        }
    }
}
