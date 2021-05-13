using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Castle.Core.Internal;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public IDataResult<Country> GetById(int countryId)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(c => c.Id == countryId));

        }

        [PerformanceAspect(5)]
        public IDataResult<List<Country>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Country>>(_countryDal.GetList().ToList());
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CountryValidator), Priority = 1)]
        [CacheRemoveAspect("ICountryService.Get")]
        public IResult Add(Country country)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _countryDal.Add(country);
            return new SuccessResult(Messages.CountryAdd);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult(Messages.CountryRemove);
        }

        [SecuredOperation("Admin")]
        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult(Messages.CountryUpdate);
        }

        [SecuredOperation("Admin")]
        public IResult TransactionalOperation(Country country)
        {
            _countryDal.Update(country);
            _countryDal.Add(country);
            return new SuccessResult(Messages.CountryUpdate);
        }
    }
}
