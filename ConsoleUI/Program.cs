using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository repo = new Repository();
            List<Medicine> medicine = repo.GetAllMedicine();
            foreach (Medicine med in medicine)
            {
                Console.WriteLine(med.Name + " " + med.Strength);
            }
        }
    }
}
