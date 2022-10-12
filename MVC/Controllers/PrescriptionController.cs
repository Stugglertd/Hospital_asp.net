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
            ViewBag.Pres = repo.TodaysPres(PhoneNumber);
            ViewBag.Patient = repo.GetPatient(PhoneNumber);
            return View();
        }

        public IActionResult SaveAddPrescription(Prescription prescription)
        {
            //return Json(prescription.MedicineName + " " + prescription.PatientPhone);
            try
            {
                bool status = repo.AddPrescription(prescription.MedicineName, prescription.PatientPhone);
                if (status)
                {
                    //Patient patient = repo.GetPatient(prescription.PatientPhone);
                    //return RedirectToAction("ViewPatientProfile", "Patient", patient);
                    return RedirectToAction("AddPrescription",new { PhoneNumber=prescription.PatientPhone });
                }
                else
                {
                    return Json("Error in Adding Prescription");
                }
            }
            catch
            {
                return Json("Exception in Adding Prescription");
            }
        }
    
        public IActionResult ShowPresOfSpecificDate(string patientPh,string Date)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions = repo.ShowPresOfSpecificDate(patientPh, Date);

            return View(prescriptions); 
            //return Json(patientPh + " " + Date);
        }
    }
}
