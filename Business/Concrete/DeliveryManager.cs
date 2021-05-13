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
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DeliveryManager : IDeliveryService
    {
        private IDeliveryDal _deliveryDal;

        public DeliveryManager(IDeliveryDal deliveryDal)
        {
            _deliveryDal = deliveryDal;
        }

        [SecuredOperation("Admin")]
        public IDataResult<Delivery> GetById(int deliveryId)
        {
            return new SuccessDataResult<Delivery>(_deliveryDal.Get(d => d.Id == deliveryId));
        }

        [SecuredOperation("Admin")]
        [PerformanceAspect(5)]
        public IDataResult<List<Delivery>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Delivery>>(_deliveryDal.GetList().ToList());
        }

        [SecuredOperation("Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Delivery>> GetListByProduct(int productId)
        {
            return new SuccessDataResult<List<Delivery>>(_deliveryDal.GetList(d => d.ProductId == productId).ToList());
        }

        [ValidationAspect(typeof(DeliveryValidator), Priority = 1)]
        [CacheRemoveAspect("IDeliveryService.Get")]
        public IResult Add(Delivery delivery)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _deliveryDal.Add(delivery);
            return new SuccessResult(Messages.DeliverySubmit);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(Delivery delivery)
        {
            _deliveryDal.Delete(delivery);
            return new SuccessResult(Messages.DeliveryRemove);
        }

        [SecuredOperation("Admin")]
        public IResult Update(Delivery delivery)
        {
            _deliveryDal.Update(delivery);
            return new SuccessResult(Messages.DeliveryUpdate);
        }

        [SecuredOperation("Admin")]
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Delivery delivery)
        {
            _deliveryDal.Update(delivery);
            _deliveryDal.Add(delivery);
            return new SuccessResult(Messages.DeliveryUpdate);
        }
    }
}
