using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class PatientController : Controller
    {
        readonly Repository repo;
        public PatientController()
        {
            repo = new Repository();
        }

        public IActionResult GetAllPatients()
        {
            List<Patient> pat;
            try
            {
              pat = repo.GetAllPatients();
            }
            catch
            {
              pat = null;
            }
            return View(pat);
        }
        public IActionResult RegisterPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveRegisterPatient(Patient patient)
        {
            try
            {
              bool status = repo.AddPatient(patient);
              if (status)
              {
                    return Json("Success");
              }
              else
              {
                    return Json("Error in Adding Patient");
              }
            }
            catch
            {
                return Json("Exception in Adding Patient");
            }
        }
        public IActionResult ViewProfile(Patient patient)
        {
          return Json(patient);
        }
    }
}
