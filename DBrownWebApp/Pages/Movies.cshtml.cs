using DBrownWebApp.Data.DAL;
using DBrownWebApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace DBrownWebApp.Pages
{
    public class MoviesModel : PageModel
    {

        public IMovieDal Dal {  get; private set; }
        public List<Movie> Movies { get; private set; }

        public MoviesModel(IMovieDal dal) 
        {
            Dal = dal;
        }


        [BindProperty]
        public Movie NewMovie { get; set; }

        public void OnGet()
        {
            NewMovie = new Movie();
            Movies = Dal.GetAllMovies().ToList();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewMovie == null) return Page();

           Dal.addMovie(NewMovie);

            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete()
        {
            //Movie toRemove = Provider.Movies.FirstOrDefault(m => m.Id == id);
            //Movies.Remove(toRemove);
            return RedirectToAction("Get");
        }
    }
}
