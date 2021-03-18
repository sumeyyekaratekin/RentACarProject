using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto()
                             {
                                 Id = c.Id,
                                 CompanyName = c.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();
            }
        }
    }
}