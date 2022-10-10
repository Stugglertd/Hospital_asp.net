using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccessLayer
{
    public class Repository
    {
        readonly DBContext context;
        public Repository()
        {
          context = new DBContext();
        }

        #region Medicine
        public List<Medicine> GetAllMedicine()
        {
            List<Medicine> Lst;
          try
          {
            Lst = (from Med in context.medicines
                   select Med).ToList();
          }
          catch (Exception ex)
          {
            Lst = null;
          }
          return Lst;
        }
        public List<string> GetMedicineNameList()
        {
            List<string> Lst;
            try
            {
              Lst = ( from Med in context.medicines
                      select Med.Name).ToList();
            }
            catch
            {
                Lst = null;
            }
            return Lst;
        }
        public bool AddMedicine(Medicine medicine)
        {
            try
            {
                context.Add(medicine);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateMedicine(string medicineName,int medicineStrength)
        {
            try
            {
                Medicine medicine = context.medicines.Find(medicineName);
                
                if (medicine == null)
                {
                    return false;
                }
                else
                {
                    medicine.Strength = medicineStrength;
                    context.Update(medicine);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteMedicine(string medicineName)
        {
            try
            {
                Medicine medicine = context.medicines.Find(medicineName);
                if(medicine == null)
                {
                    return false;
                }
                else
                {
                  context.Remove(medicine);
                  context.SaveChanges();
                  return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
    
        public List<Patient> GetAllPatients()
        {
            List<Patient> patients;
            try
            {
              patients = (from p in context.patients
                          select p).ToList();
            }
            catch
            {
              patients = null;
            }
            return patients;
        }
        public bool AddPatient(Patient patient)
        {
            try
            {
              context.patients.Add(patient);
              context.SaveChanges();
              return true;
            }
            catch
            {
              return false;
            }
        }
        public Patient GetPatient(string phoneNumber)
        {
          Patient patient;
          try
          {
            patient = context.patients.Find(phoneNumber);
          }
          catch
          {
            patient = null;
          }
          return patient;
        }
        public bool UpdatePatient(string phoneNumber,string Name,int Age,string Email,string Address)
        {
            Patient patient;
            try
            {
              patient = context.patients.Find(phoneNumber);
              if(patient == null)
              {
                return false;
              }
              else
              {
                patient.Name = Name;
                patient.Age = Age;
                patient.Email = Email;
                patient.Address = Address;
                context.Update(patient);
                context.SaveChanges();
                return true;
              }
            }
            catch
            {
                return false;
            }
        }
    
    
        
    }
}
