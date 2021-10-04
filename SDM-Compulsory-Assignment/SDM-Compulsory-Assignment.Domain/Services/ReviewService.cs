using System.Collections.Generic;
using System.Data;
using System.Linq;
using SDM_Compulsory_Assignment.Core;
using SDM_Compulsory_Assignment.Core.Models;
using SDM_Compulsory_Assignment.Domain.IRepositories;

namespace SDM_Compulsory_Assignment.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;
        private readonly IDataCRUD _crud;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _repository = reviewRepository;
        }

        public ReviewService(IDataCRUD crud)
        {
            _crud = crud;
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            // return _repository.GetNumberOfReviewsFromReviewer(reviewer);
            return _crud.ReadAll().ToList().FindAll(r => r.Reviewer == reviewer).Count;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            var reviewerReviews = _crud.ReadAll().ToList().FindAll(id => id.Reviewer == reviewer).ToList();
            double totalScore = 0;
            reviewerReviews.ForEach((review) => totalScore += review.Grade);

            return totalScore / reviewerReviews.Count;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return _crud.ReadAll().ToList().FindAll(r => r.Reviewer == reviewer && r.Grade == rate).Count;
        }

        public int GetNumberOfReviews(int movie)
        {
            return _crud.ReadAll().ToList().FindAll(m => m.Movie == movie).Count;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            var reviewerReviews = _crud.ReadAll().ToList().FindAll(id => id.Movie == movie).ToList();
            double totalScore = 0;
            reviewerReviews.ForEach((movie) => totalScore += movie.Grade);

            return totalScore / reviewerReviews.Count;
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            return _crud.ReadAll().ToList().FindAll(m => m.Movie == movie && m.Grade == rate).Count;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            List<int> movieID = new List<int>();
            var topMovies = _crud.ReadAll().ToList().FindAll(m => m.Grade == 5).OrderBy(m => m.Movie).ToList();
            topMovies.ForEach(mId => movieID.Add(mId.Movie));
            return movieID;
        }

        public List<int> GetMostProductiveReviewers()
        {
            var dic = new Dictionary<int, int>();

            var ids = new List<int>();

            var allReviewers = _crud.ReadAll().ToList();

            for (int i = 0; i < allReviewers.Count; i++)
            {
                Review review = allReviewers[i];

                if (!dic.ContainsKey(review.Reviewer))
                {
                    dic.Add(review.Reviewer, 1);
                }
                else
                {
                    dic[review.Reviewer]++;
                }
            }

            int highestAmount = dic.Values.Max();

            foreach (var entry in dic)
            {
                if (entry.Value == highestAmount)
                {
                    ids.Add(entry.Key);
                }
            }

            return ids;
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            var averageRates = new Dictionary<int, double>();
            var movies = _crud.ReadAll().OrderByDescending(x => x.Grade).Take(amount).ToList();
            for (int i = 0; i < movies.Count; i++)
            {
                var movie = movies[i];
                var averageRating = GetAverageRateOfMovie(movie.Movie);
                if (!averageRates.ContainsKey(movie.Movie))
                {
                    averageRates.Add(movie.Movie, averageRating);
                }
            }

            return averageRates.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {

           return _crud.ReadAll().Where(r => r.Reviewer == reviewer).OrderByDescending(r => r.Grade)
                .ThenByDescending(r => r.ReviewDate).Select(r => r.Movie).ToList();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return _crud.ReadAll().Where(m => m.Movie == movie).OrderByDescending(m => m.Grade)
                .ThenByDescending(m => m.ReviewDate).Select(m => m.Reviewer).ToList();
        }
    }
}