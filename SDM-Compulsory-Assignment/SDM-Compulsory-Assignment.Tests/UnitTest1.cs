using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SDM_Compulsory_Assignment.Core.Models;
using SDM_Compulsory_Assignment.Domain.IRepositories;
using SDM_Compulsory_Assignment.Domain.Services;
using SDM_Compulsory_Assignment.Infrastructure.Data.Repositories;
using Xunit;

namespace SDM_Compulsory_Assignment.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestNumberOfReviewFromReviewer()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);
            
            

            int realNumber = reviewService.GetNumberOfReviewsFromReviewer(5);
            reviewMock.Verify(n => n.ReadAll(),Times.Once);
            var expected = 1; 
            
            
            Assert.Equal(expected,realNumber);
        }

        [Fact]
        public void AverageRateFromReviewer()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 3, Movie = 667, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);

            double realNumber = reviewService.GetAverageRateFromReviewer(2);
            double expected = 3.5;
            
            Assert.Equal(expected,realNumber);

        }

        [Fact]
        public void TestNumberOfRatesByReviewer()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 3, Movie = 667, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);

            int realnumber = reviewService.GetNumberOfRatesByReviewer(2, 4);
            int expected = 1;
            
            Assert.Equal(expected,realnumber);

        }

        [Fact]
        public void TestNumberOfReviewsOnMovie()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 3, Movie = 667, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);

            int realNumber = reviewService.GetNumberOfReviews(666);
            int expected = 2;
            
            Assert.Equal(expected,realNumber);

        }

        [Fact]
        public void TestAverageRateOfMovie()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 3, Movie = 667, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);

            double realNumber = reviewService.GetAverageRateOfMovie(666);
            double expected = 4;
            
            Assert.Equal(expected,realNumber);   
        }

        [Fact]
        public void TestNumberOfRatingOnMovie()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 3, Movie = 667, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);

            int realNumber = reviewService.GetNumberOfRates(666, 4);
            int expected = 2;
            
            Assert.Equal(expected,realNumber);
        }

        [Fact]
        public void TestMoviesWithHighestNumberOfTopRates()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 3, Movie = 667, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 5, Movie = 668, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);

            var realNumber = reviewService.GetMoviesWithHighestNumberOfTopRates().Count;
            int expected = 1;
            
            Assert.Equal(expected,realNumber);
        }
        
        [Fact]
        public void TestGetMostProductiveReviewers()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 3, Movie = 667, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 5, Movie = 668, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);

            var realNumber = reviewService.GetMostProductiveReviewers().Count;
            int expected = 1;
            
            Assert.Equal(expected,realNumber);
            
        }

        [Fact]
        public void TestGetTopRatedMovies()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 3, Movie = 667, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 5, Movie = 668, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);

            var testList = reviewService.GetTopRatedMovies(2);
            var realAverage = testList[0];
            
            var expected = 668;
            
            Assert.Equal(expected,realAverage);

        }
        
        [Fact]
        public void TestGetTopMoviesByReviewer()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 3, Movie = 667, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 5, Movie = 668, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);


            var realnumber = reviewService.GetTopMoviesByReviewer(2).Count;

            var expected = 3;
            
            Assert.Equal(expected,realnumber);


        }
        
        [Fact]
        public void TestGetReviewersByMovie()
        {
            Mock<IDataCRUD> reviewMock = new Mock<IDataCRUD>();
            var reviewService = new ReviewService(reviewMock.Object);

            var Review = new List<Review>()
            {
                new Review() {Reviewer = 2, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 5, Grade = 4, Movie = 666, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 3, Movie = 667, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 5, Movie = 668, ReviewDate = DateTime.Now}
            };
            reviewMock.Setup(m => m.ReadAll()).Returns(() => Review);

            var realNumber = reviewService.GetReviewersByMovie(666).Count;

            var expected = 2;
            
            Assert.Equal(expected,realNumber);

        }
            

    }
}
