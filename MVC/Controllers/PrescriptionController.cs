using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class PrescriptionController : Controller
    {
        readonly Repository repo;
        public PrescriptionController()
        {
            repo = new Repository();
        }
    
        public IActionResult AddPrescription(string PhoneNumber)
        {
            ViewBag.PhoneNumber = PhoneNumber;
            DBContext dBContext = new DBContext();

            ViewBag.Medicine = new SelectList(dBContext.medicines,"Name", "Name");
            ViewBag.Phone = PhoneNumber;
            return View();
        }
        
        public IActionResult SaveAddPrescription(Prescription prescription)
        {
            return Json(prescription.Medicine.Name + " " + );
        }
    }
}
