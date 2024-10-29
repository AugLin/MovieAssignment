using ApplicationCore.Contract.Service;
using Microsoft.AspNetCore.Mvc;

namespace MovieAssignment.Controllers
{
    public class CastController : Controller
    {
        private readonly IMoviesServiceAsync _moviesService;
        private readonly IGenresServiceAsync _genresService;
        private readonly IMovieCastsServiceAsync _movieCastsService;
        private readonly ICastsServiceAsync _castsService;

        public CastController(IMoviesServiceAsync movieService, IGenresServiceAsync genreService, IMovieCastsServiceAsync movieCastsService, ICastsServiceAsync castsService)
        {
            _moviesService = movieService;
            _genresService = genreService;
            _movieCastsService = movieCastsService;
            _castsService = castsService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
