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
    }
}
