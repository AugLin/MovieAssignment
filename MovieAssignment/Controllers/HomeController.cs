using ApplicationCore.Contract.Service;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using MovieAssignment.Models;
using System.Diagnostics;

namespace MovieAssignment.Controllers
{
    public class HomeController : Controller
    { 
        private readonly IMoviesServiceAsync _moviesService;
        private readonly IGenresServiceAsync _genresService;
        private readonly IMovieCastsServiceAsync _movieCastsService;
        private readonly ICastsServiceAsync _castsService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMoviesServiceAsync movieService, IGenresServiceAsync genreService, IMovieCastsServiceAsync movieCastsService, ICastsServiceAsync castsService, ILogger<HomeController> logger)
        {
            _moviesService = movieService;
            _genresService = genreService;
            _movieCastsService = movieCastsService;
            _castsService = castsService;
            _logger = logger;
        }

        [Route("")]
        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            //Serilog
            _logger.LogInformation("Home Controller is being logged");

            ViewBag.Genres = await _genresService.GetAllGenreAsync();
            return View(await _moviesService.GetMostPopularMoviesAsync());
        }

        [Route("Home/Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.Genres = await _genresService.GetAllGenreAsync();
            return View("Index", await _moviesService.GetMoviesByGenreAsync(id));
        }

        public async Task<IActionResult> DetailPage(int id)
        {
            ViewBag.Genres = await _genresService.GetAllGenreAsync();

            var MovieCasts = await _movieCastsService.GetCastsByMovieIdAsync(id);
            var castDetails = new List<dynamic>();

            foreach (var movieCast in MovieCasts)
            {
                var cast = await _castsService.GetCastByIdAsync(movieCast.CastId);
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
            return View(await _moviesService.GetByIDAsync(id));
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
