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
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = (from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join co in context.Colors on c.ColorId equals co.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join im in context.CarImages on c.Id equals im.CarId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 ColorId = c.ColorId,
                                 ColorName = co.ColorName,
                                 BrandId = c.BrandId,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description, 
                                 CarImageDate = im.CarImageDate,
                                 ImagePath = im.ImagePath,
                                 ImageId = im.Id
                             }).ToList();
                return result.GroupBy(c => c.Id).Select(c=> c.FirstOrDefault()).ToList();
            }
        }


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
                        BrandName = brand.BrandName,
                        CarName = car.CarName,
                        Description = car.Description,
                        ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear
                    };
                return result.ToList(); 

            }
        }
    }
}
