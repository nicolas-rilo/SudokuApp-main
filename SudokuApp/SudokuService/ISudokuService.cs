﻿using Es.Udc.DotNet.SudokuApp.Model.SudokuDao;
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
        ISudokuDao sudokuDao{ set; }

        List<SudokuDto> findByFilter(string name, string dificulty, bool killer, bool thermal, bool arrow, bool custom, int start, int size);

        List<SudokuDto> findByUser(long userId, int start, int size);

        long uploadSudoku(SudokuDto sudokuDto);

        void reviewSudoku(long sudokuId, long usrId ,int review);

        List<Review> GetReviews(long sudokuId, int start, int size);

        int getAverageReview(long sudokuId);

        long updateSudoku(long sudokuId, SudokuDto sudokuDto);

        void removeSudoku(long sudokuId);

        long createArrow(long sudokuId, (int,int) startCell, (int, int) endCell, List<(int,int)> cells);

        List<ArrowDto> getSudokuArrows(long sudokuId);
    }
}
