using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Extensions;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filterDto)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var filterExpression = filterDto.GetFilterExpression<Car>();
                var result = from car in filterExpression == null ? context.Cars : context.Cars.Where(filterExpression)
                    join color in context.Colors on car.ColorId equals color.Id
                    join brand in context.Brands on car.BrandId equals brand.Id
                    select new CarDetailDto
                    {
                        Id = car.Id,
                        BrandName = brand.Name,
                        CarName = car.CarName,
                        Description = car.Description,
                        ColorName = color.Name,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear
                    };
                return result.ToList();

            }
        }
    }
}