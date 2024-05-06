using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.SudokuApp.Model.SudokuService
{
    public class KillerBoxDto
    {
        public long sudokuId { get; private set; }
        public int value { get; private set; }
        public List<(int, int)> cells { get; private set; }

        public KillerBoxDto(long sudokuId, int value, List<(int, int)> cells)
        {
            this.sudokuId = sudokuId;
            this.value = value;
            this.cells = cells;
        }
    }
}
