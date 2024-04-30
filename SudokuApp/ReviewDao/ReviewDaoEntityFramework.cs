using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.SudokuApp.Model.SudokuDao;
using Ninject;

namespace Es.Udc.DotNet.SudokuApp.Model.ReviewDao
{
    public class ReviewDaoEntityFramework : GenericDaoEntityFramework<Review, Int64>, IReviewDao
    {
        [Inject]
        public ISudokuDao sudokuDao { private get; set; }

        public ReviewDaoEntityFramework()
        {
        }

        public void addReview(Sudoku sudoku, Users user, int calification)
        {
            Review review = new Review();
            review.review_value = calification;
            review.sudokuId = sudoku.sudokuId;
            review.usrId = user.usrId;

            base.Create(review);
        }

        public List<Review> getSudokuReviews(Sudoku sudoku, int start, int size)
        {
            return sudoku.Review.Skip(start).Take(size).ToList();

        }

        public List<Review> getSudokuReviews(Sudoku sudoku)
        {
            return sudoku.Review.ToList();
        
        }
    }
}
