using ConsoleApp39.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ConsoleApp39.Controller
{
    internal class PassangerController
    {
        ApplicationContext ef = new ApplicationContext();
        public void AddPassanger()
        {
            Console.WriteLine();
            Console.WriteLine("Введите имя и номер пассажира с новой строки:");
            Console.WriteLine();
            Passanger passanger = new Passanger()
            {
                Name = Console.ReadLine(),
                Phone = Console.ReadLine(),
            };

            ef.Add(passanger);
            ef.SaveChanges();
        }

        public void EditPassangerName()
        {
            Console.WriteLine();
            Console.WriteLine("Введите имя, которое нужно изменить:");
            Console.WriteLine();
            var OldName = ef.Passangers.FirstOrDefault(x => x.Name == Console.ReadLine());

            if (OldName != null)
            {
                Console.WriteLine();
                Console.WriteLine("Введите новое имя:");
                Console.WriteLine();
                OldName.Name = Console.ReadLine();
            }
            
            //ef.Update(OldName);
            ef.SaveChanges();
        }
        public void ShowPassangers()
        {
            foreach (var item in ef.Tickets.Include(x => x.Passanger).Include(x => x.PointArrival).Include(x => x.PointDeparture).ToList())
            {
                Console.WriteLine($"{item?.IdTicket}, {item.Passanger?.Name}, {item.PointDeparture?.Value}-{item.PointArrival?.Value}, время отправления - {item.DateArrive}");
            }
        }
    }
}
