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
    public class ReceiverManager : IReceiverService
    {
        private IReceiverDal _receiverDal;

        public ReceiverManager(IReceiverDal receiverDal)
        {
            _receiverDal = receiverDal;
        }

        [SecuredOperation("Admin")]
        public IDataResult<Receiver> GetById(int receiverId)
        {
            return new SuccessDataResult<Receiver>(_receiverDal.Get(r => r.Id == receiverId));

        }

        [SecuredOperation("Admin")]
        [PerformanceAspect(5)]
        public IDataResult<List<Receiver>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Receiver>>(_receiverDal.GetList().ToList());
        }

        [SecuredOperation("Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Receiver>> GetListByDelivery(int deliveryId)
        {
            return new SuccessDataResult<List<Receiver>>(_receiverDal.GetList(d => d.DeliveryId == deliveryId).ToList());
        }

        [ValidationAspect(typeof(ReceiverValidator), Priority = 1)]
        [CacheRemoveAspect("IReceiverService.Get")]
        public IResult Add(Receiver receiver)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _receiverDal.Add(receiver);
            return new SuccessResult(Messages.ReceiverAdd);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(Receiver receiver)
        {
            _receiverDal.Delete(receiver);
            return new SuccessResult(Messages.ReceiverRemove);
        }

        [SecuredOperation("Admin")]
        public IResult Update(Receiver receiver)
        {
            _receiverDal.Update(receiver);
            return new SuccessResult(Messages.ReceiverUpdate);
        }

        [SecuredOperation("Admin")]
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Receiver receiver)
        {
            _receiverDal.Update(receiver);
            _receiverDal.Add(receiver);
            return new SuccessResult(Messages.ReceiverUpdate);
        }
    }
}
