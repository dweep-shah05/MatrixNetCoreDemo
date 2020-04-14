using DAL;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectCodeDemoApp.Models;
using System.Diagnostics;
using System.Linq;

namespace ProjectCodeDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _userRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/Home/User")]
        public IActionResult User()
        {
            var userData = _userRepository.Users.GetAllUserData();
            ViewBag.userData = userData;
            return View();
        }

        [HttpGet]
        [Route("/Home/UserList")]
        public IActionResult UserList()
        {
            var userData = _userRepository.Users.GetAllUserData();
            ViewBag.userData = userData.ToList();
            return View();
        }

        [HttpPost]
        [Route("/Home/UserSave")]
        public ActionResult UserSave(UserViewModel user)
        {
            DAL.Models.User dUser = new DAL.Models.User(); //We can use AutoMapper here but manually assigning because it is demo project
            dUser.Name = user.Name;
            dUser.City = user.City;
            dUser.Email = user.Email;
            dUser.Address = user.Address;
            dUser.PhoneNumber = user.PhoneNumber;
            dUser.DateCreated = System.DateTime.Now;
            dUser.DateModified = System.DateTime.Now;

            _userRepository.Users.Add(dUser);
            _userRepository.SaveChanges();

            return View("Home/User");
        }

        [HttpPost]
        [Route("/Home/UserUpdate")]
        public ActionResult UserUpdate(UserViewModel user)
        {
            DAL.Models.User dUser = new DAL.Models.User();
            dUser.Name = user.Name;
            dUser.City = user.City;
            dUser.Email = user.Email;
            dUser.Address = user.Address;
            dUser.PhoneNumber = user.PhoneNumber;
            dUser.DateCreated = System.DateTime.Now;
            dUser.DateModified = System.DateTime.Now;

            _userRepository.Users.Add(dUser);
            _userRepository.SaveChanges();

            return View("Home/User");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
