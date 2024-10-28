using ApplicationCore.Contract.Service;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using MovieAssignment.Models;
using System.Diagnostics;

namespace MovieAssignment.Controllers
{
    public class HomeController : Controller
    { 
        private readonly IMoviesService _moviesService;
        private readonly IGenresService _genresService;
        private readonly IMovieCastsService _movieCastsService;
        private readonly ICastsService _castsService;

        public HomeController(IMoviesService movieService, IGenresService genreService, IMovieCastsService movieCastsService, ICastsService castsService)
        {
            _moviesService = movieService;
            _genresService = genreService;
            _movieCastsService = movieCastsService;
            _castsService = castsService;
        }

        [Route("")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            ViewBag.Genres = _genresService.GetAllGenre();
            return View(_moviesService.GetMostPopularMovies());
        }

        [Route("Home/Index/{id}")]
        public IActionResult Index(int id)
        {
            ViewBag.Genres = _genresService.GetAllGenre();
            return View("Index", _moviesService.GetMoviesByGenre(id));
        }

        public IActionResult DetailPage(int id)
        {
            ViewBag.Genres = _genresService.GetAllGenre();

            var MovieCasts =_movieCastsService.GetCastsByMovieId(id);
            var castDetails = new List<dynamic>();

            foreach (var movieCast in MovieCasts)
            {
                var cast = _castsService.GetCastById(movieCast.CastId);
                if (cast != null)
                {
                    castDetails.Add(new
                    {
                        CastId = cast.Id,
                        Name = cast.Name,
                        ProfilePath = cast.ProfilePath,
                        Character = movieCast.Character
                    });
                }
            }
            ViewBag.Casts = castDetails;
            return View(_moviesService.GetByID(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
