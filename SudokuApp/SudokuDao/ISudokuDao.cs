using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.SudokuApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.SudokuApp.Model.SudokuDao
{
    public interface ISudokuDao : IGenericDao<Sudoku, Int64>
    {
        List<Sudoku> findByUser(Users user, int start, int size);

        List<Sudoku> findByFilter(string name, string dificulty, bool normal, bool killer, bool thermal, bool arrow, bool custom, int start, int size);
    }
}
