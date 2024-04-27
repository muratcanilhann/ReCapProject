using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CarManager : ICarService
{
    ICarDal _carDal;
    IBrandService _brandService;


    public CarManager(ICarDal carDal,IBrandService brandService)
    {
        _carDal = carDal;
        _brandService = brandService;

    }

    [ValidationAspect(typeof(CarValidator))]
    public IResult Add(Car car)
    {
       IResult result = BusinessRules.Run(CheckCarCountOfBrandCorret(car.BrandId));

        if (result != null)
        {
            return result;
        }

        _carDal.Add(car);  
        return new SuccessResult(Messages.CarAdded);
        

       
    }

    public IResult Delete(Car car)
    {
        _carDal.Delete(car);
        return new SuccessResult(Messages.CarDeleted);
    }

    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
    }

    public IDataResult<List<Car>> GetAllByBrandId(int id)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));

    }

    public IDataResult<Car> GetById(int carId)
    {
        return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
    }

    public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
    }



    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(Messages.CarUpdated);
    }


    IDataResult<List<CarDetailDto>> ICarService.GetCarDetails()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
    }

    private IResult CheckCarCountOfBrandCorret(int brandId)
    {
        var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
        if (result >= 10)
        {
            return new ErrorResult(Messages.CarCountOfBrandError);

        }
        return new SuccessResult();

    }
}
