using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {

        List<Car> _car;
        public InMemoryProductDal()
        {
            _car = new List<Car> {
            new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=400,ModelYear=1996,Description="Suitable for reservation."},
            new Car{CarId=2,BrandId=2,ColorId=2,DailyPrice=900,ModelYear=2002,Description="Suitable for reservation."},
            new Car{CarId=3,BrandId=3,ColorId=2,DailyPrice=850,ModelYear=2009,Description="Suitable for reservation."},
            new Car{CarId=4,BrandId=2,ColorId=1,DailyPrice=1200,ModelYear=2011,Description="Suitable for reservation."},
            new Car{CarId=5,BrandId=1,ColorId=1,DailyPrice=250,ModelYear=1976,Description="Suitable for reservation."},


            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            //Using Linq
            Car carToDelete = _car.SingleOrDefault(p => p.CarId == car.CarId);
            _car.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.CarId = car.CarId;       }
        public List<Car> GetAll()
        {
            return _car;
        }


        public List<Car> GetById(int BrandId)
        {
            return _car.Where(p => p.BrandId == BrandId && p.DailyPrice < 1000).ToList();

        }
    }
}
