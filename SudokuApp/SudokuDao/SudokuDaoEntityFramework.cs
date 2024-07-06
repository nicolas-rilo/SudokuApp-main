using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.SudokuApp.Model;

namespace Es.Udc.DotNet.SudokuApp.Model.SudokuDao
{
    public class SudokuDaoEntityFramework : GenericDaoEntityFramework<Sudoku, Int64>, ISudokuDao
    {
        public SudokuDaoEntityFramework()
        {
        }

        public List<Sudoku> findByFilter(string name, string dificulty,bool normal ,bool killer, bool thermal, bool arrow, bool custom, int start, int size)
        {

            DbSet<Sudoku> sudokus = Context.Set<Sudoku>();

            var result = from s in sudokus select s;

            if (name != null) {
                name = name.ToLower();
                result = result.Where(i => i.name.Contains(name));
            }

            if (dificulty != null) { 
                dificulty = dificulty.ToLower();
                result = result.Where(i => i.dificulty == dificulty);
            }

            result = normal ? result.Where(i => i.normal == true) : result;

            result =  killer ? result.Where(i => i.killer == true) : result;

            result = thermal ? result.Where(i => i.thermal == true) : result;

            result = arrow ? result.Where(i => i.arrow == true) : result;

            result = custom ? result.Where(i => i.custom == true) : result.Where(i => i == i);

            return result.OrderBy(p => p.name).Skip(start).Take(size).ToList();

        }

        public List<Sudoku> findByUser(Users user, int start, int size)
        {
            return user.Sudoku.Skip(start).Take(size).ToList();
        }
    }
}
