using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TheJoelHiltonFilmCollection.Models;

namespace TheJoelHiltonFilmCollection.Controllers
{
    // Home controller just to route to the home page and podcast page
    // Movie CRUD operations are dealt with in the movies controller
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFilmRepository _repository;

        public HomeController(ILogger<HomeController> logger, IFilmRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
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
