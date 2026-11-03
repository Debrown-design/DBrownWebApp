using DBrownWebApp.Data.DAL;
using DBrownWebApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace DBrownWebApp.Pages
{
    public class MoviesModel : PageModel
    {

        //public IMovieDal Dal { get; private set; }
        public List<Movie> Movies { get; private set; } = new List<Movie>();

        //public MoviesModel(IMovieDal dal)
        //{
        //    Dal = dal;
        //}


        [BindProperty]
        public Movie NewMovie { get; set; }

        public void OnGet()
        {
            NewMovie = new Movie();

            Movies = MovieDal.Instance.GetAllMovies().ToList();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewMovie == null) 
            { 
                Movies = MovieDal.Instance.GetAllMovies().ToList();

                return Page();
            }

           MovieDal.Instance.addMovie(NewMovie);

            return RedirectToPage();
        }

        public IActionResult OnPostDelete()
        {
            //Movie toRemove = Provider.Movies.FirstOrDefault(m => m.Id == id);
            //Movies.Remove(toRemove);
            return RedirectToAction("Get");
        }
    }
}
