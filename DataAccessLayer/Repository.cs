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
    }
}
