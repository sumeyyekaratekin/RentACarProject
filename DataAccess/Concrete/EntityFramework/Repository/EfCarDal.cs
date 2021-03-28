using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public List<CarDetailDto> GetCarDetailsById(int Id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                    join co in context.Colors on c.ColorId equals co.Id
                    join b in context.Brands on c.BrandId equals b.Id
                    join im in context.CarImages on c.Id equals im.CarId
                    where c.Id == Id
                    select new CarDetailDto
                    {
                        BrandId = b.Id,
                        BrandName = b.BrandName,
                        ColorId = co.Id,
                        ColorName = co.ColorName,
                        DailyPrice = c.DailyPrice,
                        Description = c.Description,
                        ModelYear = c.ModelYear,
                        Id = c.Id,
                        CarImageDate = im.CarImageDate,
                        ImagePath = im.ImagePath,
                        ImageId = im.Id
                    };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars.Where
                        (c => c.BrandId == brandId && c.ColorId == colorId)
                    join b in context.Brands on c.BrandId equals b.Id
                    join co in context.Colors on c.ColorId equals co.Id

                    select new CarDetailDto
                    {
                        Id = c.Id,
                        BrandName = b.BrandName,
                        ColorName = co.ColorName,
                        DailyPrice = c.DailyPrice,
                        ModelYear = c.ModelYear,
                        ImagePath = (from carImage in context.CarImages
                            where (carImage.CarId == c.Id)
                            select carImage).FirstOrDefault().ImagePath
                    };
                return result.ToList();
            }
        }
    }
}