using Es.Udc.DotNet.SudokuApp.Model.SudokuDao;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioDao;
using Es.Udc.DotNet.SudokuApp.Model.UsuarioService;
using Es.Udc.DotNet.SudokuApp.ModelUsersDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.SudokuApp.Model.SudokuService
{
    public interface ISudokuService
    {
        [Inject]
        ISudokuDao sudokuDao { set; }

        List<Sudoku > findByFilter(string name, string dificulty, bool killer, bool thermal, bool arrow, bool custom, int start, int size);

        List<Sudoku> findByUser(long userId, int start, int size);

        long uploadSudoku(SudokuDto sudokuDto);

        bool reviewSudoku(long sudokuId, int review);

        long updateSudoku(long sudokuId, SudokuDto sudokuDto);

        void removeSudoku(long sudokuId);
    }
}
