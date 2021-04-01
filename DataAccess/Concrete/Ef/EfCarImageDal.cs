using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.Ef
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentACarContext>, ICarImageDal
    {
        public bool IsExist(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.CarImages.Any(p => p.Id == id);
            }
        }

    }
}
