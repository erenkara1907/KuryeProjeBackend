using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public IDataResult<City> GetById(int cityId)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.Id == cityId));
        }

        [PerformanceAspect(5)]
        public IDataResult<List<City>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<City>>(_cityDal.GetList().ToList());
        }

        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<City>> GetListByCountry(int countryId)
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetList(c => c.CountryId == countryId).ToList());
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CityValidator), Priority = 1)]
        [CacheRemoveAspect("ICityService.Get")]
        public IResult Add(City city)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _cityDal.Add(city);
            return new SuccessResult(Messages.CityAdd);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult(Messages.CityRemove);
        }

        [SecuredOperation("Admin")]
        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult(Messages.CityUpdate);
        }

        [SecuredOperation("Admin")]
        public IResult TransactionalOperation(City city)
        {
            _cityDal.Update(city);
            _cityDal.Add(city);
            return new SuccessResult(Messages.CityUpdate);
        }
    }
}
