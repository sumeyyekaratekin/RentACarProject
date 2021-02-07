using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Repository;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

           
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.CarId}\t{car.CarName}\t" +
                    $"{colorManager.GetById(car.ColorId).ColorName}\t" +
                    $"{brandManager.GetById(car.BrandId).BrandName}\t" +
                    $"{car.ModelYear}\t\t{car.DailyPrice} TL\t" +
                    $",{car.Descriptions}");
                Console.WriteLine("-------------------------------------------------------------------------------------");
            }
        }
    }
}