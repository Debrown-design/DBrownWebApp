using DBrownWebApp.Data.Models;
using System.Reflection;
using static System.Formats.Asn1.AsnWriter;

namespace DBrownWebApp.Data.DAL
{
    public class MovieDal : IMovieDal
    {
        private static List<Movie> movies = new List<Movie>() {
                new Movie() { Title = "The Prestige", Year = 2006, Score = 8.6f },
                new Movie() { Title = "8-Legged Freaks", Year = 2002, Score = 5.5f },
                new Movie() { Title = "The Purge", Year = 2013, Score = 5.7f },
                new Movie() { Title = "Avatar", Year = 2009, Score = 7.9f }
        };
                
        public IEnumerable<Movie> GetAllMovies() 
        {
            return movies;
        }

        public void addMovie(Movie movie)
        {
            if (movie != null)
            {
                movies.Add(movie);
            }
        }
    }
}
