using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.SudokuApp.Model.CellDao;
using Es.Udc.DotNet.SudokuApp.Model.SudokuDao;
using Es.Udc.DotNet.SudokuApp.ModelUsersDao;
using Ninject;

namespace Es.Udc.DotNet.SudokuApp.Model.SudokuService
{
    public class SudokuService : ISudokuService
    {
        [Inject]
        public IUsersDao usersDao{ private get; set; }
        [Inject]
        public ICellDao cellDao{ private get; set; }
        [Inject]
        public ISudokuDao sudokuDao { private get; set; }

        public List<Sudoku> findByFilter(string name, string dificulty, bool killer, bool thermal, bool arrow, bool custom, int start, int size)
        {
            return sudokuDao.findByFilter(name, dificulty, killer, thermal, arrow, custom, start, size);
        }

        public List<Sudoku> findByUser(long userId, int start, int size)
        {
            Users user = usersDao.Find(userId);
            return sudokuDao.findByUser(user, start, size);
        }

        public void removeSudoku(long sudokuId)
        {
            Sudoku sudoku = sudokuDao.Find(sudokuId);
            if (sudoku == null)
            {
                throw new InstanceNotFoundException();
            }

            sudokuDao.Remove(sudokuId);
        }

        public bool reviewSudoku(long sudokuId, int review)
        {
            throw new NotImplementedException();
        }

        public long updateSudoku(long sudokuId, SudokuDto sudokuDto)
        {
            Sudoku sudoku = new Sudoku();
            sudoku.usrId = sudokuDto.userId;
            sudoku.name = sudokuDto.name;
            sudoku.rules = sudokuDto.rules;
            sudoku.dificulty = sudokuDto.dificulty;
            sudoku.normal = sudokuDto.nomal;
            sudoku.killer = sudokuDto.killer;
            sudoku.thermal = sudokuDto.thermal;
            sudoku.arrow = sudokuDto.arrow;
            sudoku.custom = sudokuDto.custom;

            sudokuDao.Update(sudoku);

           // cellDao.addCellsToSudokuPuzzle(sudoku, sudokuDto.puzzle);
           // cellDao.addCellsToSudokuSolution(sudoku, sudokuDto.solution);

            return sudoku.sudokuId;
        }

        public long uploadSudoku(SudokuDto sudokuDto)
        {
            Sudoku sudoku = new Sudoku();
            sudoku.usrId = sudokuDto.userId;
            sudoku.name = sudokuDto.name;
            sudoku.rules = sudokuDto.rules;
            sudoku.dificulty = sudokuDto.dificulty;
            sudoku.normal = sudokuDto.nomal;
            sudoku.killer = sudokuDto.killer;
            sudoku.thermal = sudokuDto.thermal;
            sudoku.arrow = sudokuDto.arrow;
            sudoku.custom = sudokuDto.custom;

            sudokuDao.Create(sudoku);

            cellDao.addCellsToSudokuPuzzle(sudoku, sudokuDto.puzzle);
            cellDao.addCellsToSudokuSolution(sudoku, sudokuDto.solution);

            return sudoku.sudokuId;
        }
    }
}
