using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
            List<Patient> pat = new List<Patient>();
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
                    return RedirectToAction("ViewPatientProfile", patient);
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
        public IActionResult ViewPatientProfile(Patient patient)
        {
          
            List<DateTime> dateList = repo.GetAllDates(patient.PhoneNumber);
            List<string> dateListStr = new List<string>();

            foreach (var dt in dateList)
            {
                dateListStr.Add(dt.Date.ToString("dd/MM/yyyy"));    
            }

            ViewBag.dateList = dateListStr;
            ViewBag.phone = patient.PhoneNumber;
            
            return View(patient);
        }
        public IActionResult UpdatePatient(string phoneNumber)
        {
            Patient pat = repo.GetPatient(phoneNumber);
            ViewBag.Patient = pat;
            return View(pat);
        }
        [HttpPost]
        public IActionResult SaveUpdatePatient(Patient patient)
        {
            try
            {
                bool status = 
                 repo.UpdatePatient(patient.PhoneNumber,patient.Name,patient.Age,patient.Email,patient.Address);
                if(status)
                {
                    return RedirectToAction("ViewPatientProfile",patient);
                }
                else
                {
                    return Json("Error in Updating Patient");
                }
            }
            catch
            {
                return Json("Exception in Updating Patient");
            }
        }
    }
}
