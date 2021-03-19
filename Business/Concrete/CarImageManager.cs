using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImagesDto carImagesDto)
        {
            var result = BusinessRules.Run(CheckCarImagesCount(carImagesDto.CarId));
            if (result != null) return result;
            CarImage carimage = new CarImage
            {
                CarId = carImagesDto.CarId,
                ImagePath = FileHelpers.SaveImageFile(carImagesDto.ImageFile),
                CarImageDate = DateTime.Now
            };
            _carImageDal.Add(carimage);
            return new SuccessResult(Messages.AddedCarImage);
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImagesDto carImagesDto)
        {
            var result = _carImageDal.Get(ci => ci.Id == carImagesDto.Id);
            if (result == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelpers.DeleteImageFile(result.ImagePath);
            result.ImagePath = FileHelpers.SaveImageFile(carImagesDto.ImageFile);
            result.CarImageDate = DateTime.Now;
            _carImageDal.Update(result);
            return new SuccessResult(Messages.UpdatedCarImage);
        }

        public IResult Delete(CarImagesDto carImagesDto)
        {
            var result = _carImageDal.Get(ci => ci.Id == carImagesDto.Id);
            if (result == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelpers.DeleteImageFile(result.ImagePath);
            _carImageDal.Delete(result);
            return new SuccessResult(Messages.DeletedCarImage);
        }

        private IResult CheckCarImagesCount(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count < 5;
            if (!result) return new ErrorResult(Messages.FailedCarImageAdd);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            CarImage result = _carImageDal.Get(ci => ci.Id == carImageId);
            if (result == null) return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Any()) return new SuccessDataResult<List<CarImage>>(result);
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>
            {
                new CarImage{  CarId = carId,  ImagePath = "default.jpg", CarImageDate = DateTime.Now }
            });
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult DeleteByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            foreach (var item in result)
            {
                FileHelpers.DeleteImageFile(item.ImagePath);
                _carImageDal.Delete(item);
            }
            return new SuccessResult(Messages.DeletedCarImage);
        }
    }
}