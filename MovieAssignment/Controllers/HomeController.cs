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
       
        public HomeController(IMoviesService movieService, IGenresService genreService)
        {
            _moviesService = movieService;
            _genresService = genreService;
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
