﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.SudokuApp.Model.CellDao;
using Es.Udc.DotNet.SudokuApp.Model.ReviewDao;
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
        [Inject]
        public IReviewDao reviewDao { private get; set; }


        public List<SudokuDto> findByFilter(string name, string dificulty, bool killer, bool thermal, bool arrow, bool custom, int start, int size)
        {
            List<Sudoku> sudokus = sudokuDao.findByFilter(name, dificulty, killer, thermal, arrow, custom, start, size);
            List<SudokuDto> sudokuDtos = new List<SudokuDto>();


            foreach (Sudoku s in sudokus){
                sudokuDtos.Add(sudokuToSudokudto(s));
            }

            return sudokuDtos;
        }


        private SudokuDto sudokuToSudokudto (Sudoku sudoku) {
            return new SudokuDto(sudoku.usrId,sudoku.name,sudoku.rules,sudoku.dificulty, (bool)sudoku.normal, (bool)sudoku.killer,
                (bool)sudoku.thermal, (bool)sudoku.arrow, (bool)sudoku.custom, cellDao.getSudokuCellPuzzle(sudoku), cellDao.getSudokuCellSolution(sudoku));
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

            cellDao.addCellsToSudokuPuzzle(sudoku, sudokuDto.puzzle);
            cellDao.addCellsToSudokuSolution(sudoku, sudokuDto.solution);

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

            foreach (Review a in reviews) {
                total += (int) a.review_value;    
            }

            double result = total / reviews.Count();
            return (int) Math.Round(result);

        }
    }
}
