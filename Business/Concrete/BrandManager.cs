using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.BusinessAspect.Autofac;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        //[ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);            
            return new SuccessResult(Messages.AddedBrand);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.DeletedBrand);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
        }

        //[ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("admin")]
        public IResult Update(Brand brand)
        {
            
            _brandDal.Update(brand);
            return new SuccessResult(Messages.UpdatedBrand);
            
        }
    }
}
