using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.SudokuApp.Model.SudokuService
{
    [Serializable]
    public class SudokuDto
    {
        public long sudokuId { get; private set; }
        public long userId { get; private set; }
        public string name { get; private set; }
        public string rules { get; private set; }
        public string dificulty { get; private set; }
        public long review { get; set; }
        public bool nomal { get; private set; }
        public bool killer { get; private set; }
        public bool thermal { get; private set; }
        public bool arrow { get; private set; }
        public bool custom { get; private set; }
        public int[,] puzzle { get; private set; }
        public int[,] solution { get; private set; }
        public int[,] image { get; private set; }

        public SudokuDto(long sudokuId, long userId, string name, string rules, 
            string dificulty, bool nomal, bool killer, bool thermal, bool arrow, 
            bool custom, int[,] puzzle, int[,] solution, int[,] image)
        {
            this.sudokuId = sudokuId;
            this.userId = userId;
            this.name = name;
            this.rules = rules;
            this.dificulty = dificulty;
            this.nomal = nomal;
            this.killer = killer;
            this.thermal = thermal;
            this.arrow = arrow;
            this.custom = custom;
            this.puzzle = puzzle;
            this.solution = solution;
            this.image = image;
        }
    }
}
