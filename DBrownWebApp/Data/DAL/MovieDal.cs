using DBrownWebApp.Data.Models;
using System.Reflection;
using static System.Formats.Asn1.AsnWriter;

namespace DBrownWebApp.Data.DAL
{
    public sealed class MovieDal : IMovieDal
    {
        

        public static MovieDal _instance;

        private static readonly object _lock = new object();

        private List<Movie> _movies;
        private int _nextId = 104;

        private MovieDal()
        {
            _movies = new List<Movie>()
            {
                new Movie() { Title = "The Prestige", Year = 2006, Score = 8.6f },
                new Movie() { Title = "8-Legged Freaks", Year = 2002, Score = 5.5f },
                new Movie() { Title = "The Purge", Year = 2013, Score = 5.7f },
                new Movie() { Title = "Avatar", Year = 2009, Score = 7.9f }
            };
        }

        //private static List<Movie> movies = new List<Movie>() {
        //        new Movie() { Title = "The Prestige", Year = 2006, Score = 8.6f },
        //        new Movie() { Title = "8-Legged Freaks", Year = 2002, Score = 5.5f },
        //        new Movie() { Title = "The Purge", Year = 2013, Score = 5.7f },
        //        new Movie() { Title = "Avatar", Year = 2009, Score = 7.9f }
        //};
        public static MovieDal Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MovieDal();
                    }
                    return _instance;
                }

            }
           
        }
                
        public IEnumerable<Movie> GetAllMovies() 
        {
            return _movies;
        }

        public void addMovie(Movie movie)
        {
            if (movie != null)
            {
                movie.Id = _nextId++;
                _movies.Add(movie);
            }
        }
        public void deleteMovie(int id)
        {
            Movie movieToRemove = _movies.FirstOrDefault(m => m.Id == id);
            if (movieToRemove != null)
            {
                _movies.Remove(movieToRemove);
            }
        }
    }
}
