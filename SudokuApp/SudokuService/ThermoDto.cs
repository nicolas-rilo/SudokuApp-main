using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.SudokuApp.Model.SudokuService
{
    public class ThermoDto
    {
        public long sudokuId { get; set; }
        public (int, int) startCell { get; private set; }
        public (int, int) endCell { get; private set; }
        public List<(int, int)> cells { get; private set; }

        public ThermoDto(long sudokuId, (int, int) startCell, (int, int) endCell, List<(int, int)> cells)
        {
            this.sudokuId = sudokuId;
            this.startCell = startCell;
            this.endCell = endCell;
            this.cells = cells;
        }
    }
}
