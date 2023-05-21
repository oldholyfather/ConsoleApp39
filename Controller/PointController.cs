using ConsoleApp39.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp39.Controller
{
    internal class PointController
    {
        ApplicationContext ef = new ApplicationContext();

        public void AddPoint()
        {
            Console.WriteLine();
            Console.WriteLine("Введите название города:");
            Console.WriteLine();

            Point point = new Point() { Value = Console.ReadLine() };

            ef.Add(point);
            ef.SaveChanges();
        }
    }
}
