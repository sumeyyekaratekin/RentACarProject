using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;

        }

        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.AddedCar);

        }

        public IResult Delete(Car car)
        {
            _carImageService.DeleteByCarId(car.Id);
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedCar);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new SuccessResult(Messages.UpdatedCar);
        }

        //[CacheAspect(duration: 10)]
        //[LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            Thread.Sleep(500);
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        //[CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetCarsByBrandId(brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetCarsByColorId(colorId));
        }
       
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.UpdatedCar);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());

        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.Id == carId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == ColorId));

        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == BrandId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailByBrandIdAndColorId(int brandId, int colorId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarDetails(p => p.BrandId == brandId && p.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.GetErrorCarMessage);
            }
        }

    }
}