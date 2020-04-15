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
            return RedirectToAction(nameof(UserList));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/Home/User")]
        public IActionResult User()
        {
            return View();
        }

        [HttpGet]
        [Route("/Home/UserList")]
        public IActionResult UserList()
        {
            var userData = _userRepository.Users.GetAllUserData();
            return View(userData);
        }

        [HttpGet]
        [Route("/Home/EditUser")]
        public IActionResult Edit(int id)
        {
            var userData = _userRepository.Users.GetUser(id);
            return View(userData);
        }

        [HttpGet]
        [Route("/Home/DeleteUser")]
        public IActionResult Delete(int id)
        {
            var userData = _userRepository.Users.GetUser(id);
            _userRepository.Users.Remove(userData);
            _userRepository.SaveChanges();
            return RedirectToAction(nameof(UserList));
        }

        [HttpPost]
        [Route("/Home/UserSave")]
        public ActionResult UserSave(UserViewModel user)
        {
            DAL.Models.User dUser = new DAL.Models.User()
            {
                Name = user.Name,
                City = user.City,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                DateCreated = System.DateTime.Now,
                DateModified = System.DateTime.Now,
            };

            _userRepository.Users.Add(dUser);
            _userRepository.SaveChanges();

            return RedirectToAction(nameof(UserList));
        }

        [HttpPost]
        [Route("/Home/UserUpdate")]
        public ActionResult UserUpdate(UserViewModel user)
        {
            DAL.Models.User dUser = new DAL.Models.User()
            {
                Id = user.Id,
                Name = user.Name,
                City = user.City,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                DateCreated = System.DateTime.Now,
                DateModified = System.DateTime.Now,
            };
            _userRepository.Users.Update(dUser);
            _userRepository.SaveChanges();

            return RedirectToAction(nameof(UserList));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
