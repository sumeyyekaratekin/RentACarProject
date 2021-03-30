﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rent in context.Rentals
                    join car in context.Cars
                        on rent.CarId equals car.Id
                    join brand in context.Brands
                        on car.BrandId equals brand.Id
                    join customer in context.Customers
                        on rent.UserId equals customer.UserId
                    join user in context.Users
                        on customer.UserId equals user.Id
                    select new RentalDetailDto
                    {
                        RentalId = rent.Id,
                        CarName = car.CarName,
                        CustomerFullName = user.FirstName + user.LastName,
                        RentDate = rent.RentDate,
                        RentStartDate = rent.RentStartDate,
                        RentEndDate = rent.RentEndDate,
                        ReturnDate = rent.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}