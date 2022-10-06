using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MedicineController : Controller
    {
        readonly Repository repo;
        public MedicineController()
        {
          repo = new Repository();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult GetAllMedicine()
        {
            var result = repo.GetAllMedicine();
            return View(result);
            //return Json(result);
        }
    }
}
