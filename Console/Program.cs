using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carmanager = new CarManager(new InMemoryProductDal());
            foreach (var car in carmanager.GetAll())
            {
                Console.WriteLine("Brand : "+car.BrandId+" Daily Price :" +car.DailyPrice+" TL");
            }
        }
    }
}
