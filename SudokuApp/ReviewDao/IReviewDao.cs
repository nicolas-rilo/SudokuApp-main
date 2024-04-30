using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.SudokuApp.Model.ReviewDao
{
    public interface IReviewDao : IGenericDao<Review, Int64>
    {
        void addReview(Sudoku sudoku, Users user ,int calification);

        List<Review> getSudokuReviews(Sudoku sudoku, int start, int size);

        List<Review> getSudokuReviews(Sudoku sudoku);

    }
}
