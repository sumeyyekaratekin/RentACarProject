using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
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
        public List<CustomerDetailDto> GetCustomerList()
        {
            using (RentACarContext context = new RentACarContext())
            {
                IQueryable<CustomerDetailDto> customerDetails = from u in context.Users
                                                                join c in context.Customers
                                                                on u.Id equals c.UserId
                                                                select new CustomerDetailDto
                                                                {
                                                                    //UserId = u.Id,
                                                                    //CustomerId = c.Id,
                                                                    CustomerName = u.FirstName + " " + u.LastName,
                                                                    CompanyName = c.CompanyName,

                                                                };
                return customerDetails.ToList();
            }
        }
    }
}