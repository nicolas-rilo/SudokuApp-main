﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.SudokuApp.Model.CellDao
{
    public interface ICellDao : IGenericDao<Cell, Int64>
    {
        void addCellsToSudokuPuzzle(Sudoku sudoku, int[,] puzzle);

        void addCellsToSudokuSolution(Sudoku sudoku, int[,] solution);

    }
}
