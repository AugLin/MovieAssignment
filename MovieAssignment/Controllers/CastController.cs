using ApplicationCore.Contract.Service;
using Microsoft.AspNetCore.Mvc;

namespace MovieAssignment.Controllers
{
    public class CastController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly IGenresService _genresService;
        private readonly IMovieCastsService _movieCastsService;
        private readonly ICastsService _castsService;

        public CastController(IMoviesService movieService, IGenresService genreService, IMovieCastsService movieCastsService, ICastsService castsService)
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
