using DataAccessLayer;
using DataAccessLayer.Models;
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
        public IActionResult GetAllMedicine()
        {
            var result = repo.GetAllMedicine();
            return View(result);
        }

        public IActionResult AddMedicine()
        {
          return View();
        }
        [HttpPost]
        public IActionResult SaveAddMedicine(Medicine medicine)
        {
            try
            {
                bool status = repo.AddMedicine(medicine);
                if (status)
                {
                    return Redirect("GetAllMedicine");
                }
                else
                {
                    return Json("Error in adding");
                }
            }
            catch
            {
                return Json("Exception in adding");
            }
        }
    
        public IActionResult UpdateMedicine(Medicine medicine)
        {
            return View(medicine);
        }
        [HttpPost]
        public IActionResult SaveUpdateMedicine(Medicine medicine)
        {
            try
            {
                bool status = repo.UpdateMedicine(medicine.Name,medicine.Strength);
                if (status)
                {
                    return Redirect("GetAllMedicine");
                }
                else
                {
                    return Json("Error in Updating");
                }
            }
            catch
            {
                return Json("Exception in Updating");
            }
        }
   
        public IActionResult DeleteMedicine(Medicine medicine)
        {
            return View(medicine);
        }
        [HttpPost]
        public IActionResult SaveDeleteMedicine(string medicineName)
        {
            try
            {
                bool status = repo.DeleteMedicine(medicineName);
                if (status)
                {
                    return Redirect("GetAllMedicine");
                }
                else
                {
                    return Json("Error in Deleting");
                }
            }
            catch
            {
                return Json("Exception in Deleting");
            }
        }
    }
}
