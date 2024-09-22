using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.SudokuApp.Model.ArrowDao;
using Es.Udc.DotNet.SudokuApp.Model.CellDao;
using Es.Udc.DotNet.SudokuApp.Model.KillerDao;
using Es.Udc.DotNet.SudokuApp.Model.ReviewDao;
using Es.Udc.DotNet.SudokuApp.Model.SudokuDao;
using Es.Udc.DotNet.SudokuApp.Model.ThermoDao;
using Es.Udc.DotNet.SudokuApp.ModelUsersDao;
using Ninject;
using SudokuGame;

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
        [Inject]
        public IReviewDao reviewDao { private get; set; }
        [Inject]
        public IArrowDao arrowDao { private get; set; }
        [Inject]
        public IKillerBoxDao killerDao { private get; set; }
        [Inject]
        public IThermoDao thermoDao { private get; set; }

        public List<SudokuDto> findByFilter(string name,  string dificulty, bool normal, bool killer, bool thermal, bool arrow, bool custom, int start, int size)
        {
            List<Sudoku> sudokus = sudokuDao.findByFilter(name, dificulty, normal, killer, thermal, arrow, custom, start, size);
            List<SudokuDto> sudokuDtos = new List<SudokuDto>();


            foreach (Sudoku s in sudokus){
                sudokuDtos.Add(sudokuToSudokudto(s));
            }

            return sudokuDtos;
        }


        private SudokuDto sudokuToSudokudto (Sudoku sudoku) {
            SudokuDto sudokuDto = new SudokuDto(sudoku.sudokuId, sudoku.usrId, sudoku.name, sudoku.rules, sudoku.dificulty, (bool)sudoku.normal, (bool)sudoku.killer,
                (bool)sudoku.thermal, (bool)sudoku.arrow, (bool)sudoku.custom, cellDao.getSudokuCellPuzzle(sudoku), cellDao.getSudokuCellSolution(sudoku), cellDao.getSudokuCellImage(sudoku));

            sudokuDto.review = getAverageReview(sudoku.sudokuId);

            return sudokuDto;
        }

        public List<SudokuDto> findByUser(long userId, int start, int size)
        {
            Users user = usersDao.Find(userId);
            List<Sudoku> sudokus = sudokuDao.findByUser(user, start, size);
            List<SudokuDto> sudokuDtos = new List<SudokuDto>();

            foreach (Sudoku s in sudokus) {
                sudokuDtos.Add(sudokuToSudokudto(s));
            }

            return sudokuDtos;
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

        public void reviewSudoku(long sudokuId, long usrId, int review)
        {
            reviewDao.addReview(sudokuDao.Find(sudokuId),usersDao.Find(usrId),review);
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

            cellDao.addCellsAndImageToSudokuPuzzle(sudoku, sudokuDto.puzzle, sudokuDto.image);
            cellDao.addCellsAndImageToSudokuSolution(sudoku, sudokuDto.solution, sudokuDto.image);

            return sudoku.sudokuId;
        }

        public List<Review> GetReviews(long sudokuId, int start, int size)
        {
            return reviewDao.getSudokuReviews(sudokuDao.Find(sudokuId), start, size);
        }

        public int getAverageReview(long sudokuId)
        {
            List<Review> reviews = reviewDao.getSudokuReviews(sudokuDao.Find(sudokuId));
            int total = 0;
            double result;

            foreach (Review a in reviews) {
                total += (int) a.review_value;    
            }
            if (reviews.Count() != 0)
            {
                result = total / reviews.Count();
            }
            else {
                result = 0;
            }
            return (int) Math.Round(result);

        }

        public long createArrow(long sudokuId, (int, int) startCell, (int, int) endCell, List<(int, int)> cells)
        {
            Sudoku sudoku = sudokuDao.Find(sudokuId);
            long start = cellDao.getCellIdByPosition(sudoku,startCell);
            long end = cellDao.getCellIdByPosition(sudoku, endCell);

            Arrow arrow = new Arrow();
            arrow.sudokuId = sudokuId;
            arrow.start_cell = start;
            arrow.end_cell = end;

            arrowDao.Create(arrow);
            sudoku.Arrow1.Add(arrow);
            sudokuDao.Update(sudoku);

            foreach ((int, int) a in cells)
            {
                Cell cell = cellDao.getCellByPosition(sudoku, a);
                cell.Arrow2.Add(arrow);
                cellDao.Update(cell);

            }

            return arrow.arrowId;
        }

        private List<(int,int)> cellsToTuple(List<Cell> cells)
        {
            List<(int, int)> ps = new List<(int, int)>();

            foreach (Cell c in cells) {
                ps.Add(((int) c.row_index,(int) c.col_index));
            }

            return ps;
        }

        public List<ArrowDto> getSudokuArrows(long sudokuId)
        {
            Sudoku sudoku = sudokuDao.Find(sudokuId);
            List<Arrow> arrows = sudoku.Arrow1.ToList();
            List<ArrowDto> arrowDtos = new List<ArrowDto>();

            foreach (Arrow a in arrows) {
                ArrowDto arrowDto = new ArrowDto(sudokuId,
                    ((int) cellDao.Find(a.start_cell).row_index, (int)cellDao.Find(a.start_cell).col_index),
                    ((int) cellDao.Find(a.end_cell).row_index, (int)cellDao.Find(a.end_cell).col_index),
                    cellsToTuple(a.Cell2.ToList()));
                arrowDtos.Add(arrowDto);
            
            }
            return arrowDtos;
        }

        public long createKillerBox(long sudokuId, int value, List<(int, int)> cells)
        {
            Sudoku sudoku = sudokuDao.Find(sudokuId);

            Killer_box killer_Box = new Killer_box();
            killer_Box.sudokuId = sudokuId;
            killer_Box.killer_value = value;

            killerDao.Create(killer_Box);
            sudoku.Killer_box.Add(killer_Box);
            sudokuDao.Update(sudoku);


            foreach ((int, int) a in cells)
            {
                Cell cell = cellDao.getCellByPosition(sudoku, a);
                cell.Killer_box.Add(killer_Box);
                cellDao.Update(cell);

            }
            return killer_Box.killerId;
        }

        public List<KillerBoxDto> getSudokuKillerBox(long sudokuId)
        {
            Sudoku sudoku = sudokuDao.Find(sudokuId);
            List<Killer_box> killer_Boxes = sudoku.Killer_box.ToList();
            List<KillerBoxDto> killerBoxDtos = new List<KillerBoxDto>();

            foreach (Killer_box k in killer_Boxes)
            {
                KillerBoxDto killerBoxDto = new KillerBoxDto(sudokuId,(int)k.killer_value,cellsToTuple(k.Cell.ToList()));
                killerBoxDtos.Add(killerBoxDto);

            }
            return killerBoxDtos;
        }

        public long createThermo(long sudokuId, (int, int) startCell, (int, int) endCell, List<(int, int)> cells)
        {
            Sudoku sudoku = sudokuDao.Find(sudokuId);
            long start = cellDao.getCellIdByPosition(sudoku, startCell);
            long end = cellDao.getCellIdByPosition(sudoku, endCell);

            Thermo thermo = new Thermo();
            thermo.sudokuId = sudokuId;
            thermo.start_cell = start;
            thermo.end_cell = end;

            thermoDao.Create(thermo);
            sudoku.Thermo.Add(thermo);
            sudokuDao.Update(sudoku);
            if (cells != null)
            {
                foreach ((int, int) a in cells)
                {
                    Cell cell = cellDao.getCellByPosition(sudoku, a);
                    cell.Thermo2.Add(thermo);
                    cellDao.Update(cell);

                }
            }


            return thermo.thermoId;
        }

        public List<ThermoDto> getSudokuThermos(long sudokuId)
        {
            Sudoku sudoku = sudokuDao.Find(sudokuId);
            List<Thermo> thermos = sudoku.Thermo.ToList();
            List<ThermoDto> thermoDtos = new List<ThermoDto>();

            foreach (Thermo t in thermos)
            {
                ThermoDto thermoDto = new ThermoDto(sudokuId,
                    ((int)cellDao.Find(t.start_cell).row_index, (int)cellDao.Find(t.start_cell).col_index),
                    ((int)cellDao.Find(t.end_cell).row_index, (int)cellDao.Find(t.end_cell).col_index),
                    cellsToTuple(t.Cell2.ToList()));
                thermoDtos.Add(thermoDto);

            }
            return thermoDtos;
        }

        private int[,] stringToIntArray(string array) {
            int[,] result= new int[9, 9];
            string array2 =new string( array.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());

            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) 
                {
                    int pos = j;
                    if (i > 0)
                    {
                        pos += i * 9;
                    }
                    result[i, j] = ((int) array2[pos])-48;
                
                
                }
            
            }


            return result;
        }

        public SudokuDto generateSudoku(int dificulty)
        {
            String dificultyDto = null;
            int[,] solution = null ;
            int[,] puzzle = null;

            SudokuGenerator sudokuGenerator = new SudokuGenerator(gridsPerLevel: 1);
            sudokuGenerator.ExecuteAll();

            if (dificulty == 0) dificultyDto = "Easy";
            if (dificulty == 1) dificultyDto = "Medium";
            if (dificulty == 2) dificultyDto = "Hard";


            SudokuSolver sudokuSolver = new SudokuSolver(sudokuGenerator.getSudoku(dificulty));

            solution = stringToIntArray(sudokuSolver.Execute(displaySolution: false, displayGrid: false));
            puzzle = stringToIntArray(sudokuGenerator.getSudoku(dificulty));


            SudokuDto sudokuDto = new SudokuDto(0,0, "Generates", "no rules", dificultyDto, true, false, false,
                                    false, false, puzzle, solution,null);
            return sudokuDto;
        }

        public List<SudokuDto> findSudoku(long sudokuId)
        {
            List<SudokuDto> sudokuDtos = new List<SudokuDto>();
            sudokuDtos.Add(sudokuToSudokudto( sudokuDao.Find(sudokuId)));
            return sudokuDtos;
        }
    }
}
