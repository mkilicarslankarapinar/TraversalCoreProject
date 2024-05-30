using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;

        public UserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }


        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            return RedirectToAction("values");
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }
        public IActionResult CommentUser(int id) 
        {
            _appUserService.TGetList();
            return View();
        }
        public IActionResult ReservationUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }
    }
}
