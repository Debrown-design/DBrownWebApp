using DBrownWebApp.Data.DAL;
using DBrownWebApp.Data.Models;
using DBrownWebApp.Data.Strategies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBrownWebApp.Pages
{
    public class MoviesModel : PageModel
    {
        private readonly IMovieDal _movieDal;
        private readonly MovieSortContext _movieSortContext;

        public List<Movie> Movies { get; private set; } = new List<Movie>();

        [BindProperty]
        public Movie NewMovie { get; set; } = new Movie();

        [BindProperty(SupportsGet = true)]
        public string Sort { get; set; } = "title";

        public MoviesModel(
            IMovieDal movieDal,
            MovieSortContext movieSortContext)
        {
            _movieDal = movieDal;
            _movieSortContext = movieSortContext;
        }

        public void OnGet()
        {
            LoadMovies();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadMovies();

                return Page();
            }

            _movieDal.addMovie(NewMovie);

            return RedirectToPage(new { sort = Sort });
        }

        private void LoadMovies()
        {
            Movies = _movieSortContext
                .Sort(_movieDal.GetAllMovies(), Sort)
                .ToList();
        }
    }
}
