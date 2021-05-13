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
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        [SecuredOperation("Admin")]
        public IDataResult<Address> GetById(int addressId)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(a => a.Id == addressId));
        }

        [SecuredOperation("Admin")]
        [PerformanceAspect(5)]
        public IDataResult<List<Address>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Address>>(_addressDal.GetList().ToList());
        }

        [SecuredOperation("Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Address>> GetListByUser(int userId)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetList(a => a.UserId == userId).ToList());

        }

        [ValidationAspect(typeof(AddressValidator), Priority = 1)]
        [CacheRemoveAspect("IAddressService.Get")]
        public IResult Add(Address address)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _addressDal.Add(address);
            return new SuccessResult(Messages.AddressAdd);
        }

        public IResult Delete(Address address)
        {
            _addressDal.Delete(address);
            return new SuccessResult(Messages.AddressRemove);
        }

        public IResult Update(Address address)
        {
            _addressDal.Update(address);
            return new SuccessResult(Messages.AddressUpdate);
        }

        public IResult TransactionalOperation(Address address)
        {
            _addressDal.Update(address);
            _addressDal.Add(address);
            return new SuccessResult(Messages.AddressUpdate);
        }
    }
}
