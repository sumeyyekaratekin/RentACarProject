using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IEntityServiceBase<Car>
    {
        IDataResult<List<Car>> GetCarsByBrand(int brandId);
        IDataResult<List<Car>> GetCarsByColor(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsDetails(CarDetailFilterDto filterDto);
    }
}
