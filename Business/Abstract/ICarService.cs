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
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailByBrandIdAndColorId(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int id);
        IResult TransactionalOperation(Car car);
    }
}
