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
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [SecuredOperation("Admin")]
        public IDataResult<OperationClaim> GetById(int operationClaimId)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Id == operationClaimId));
        }

        [SecuredOperation("Admin")]
        [PerformanceAspect(5)]
        public IDataResult<List<OperationClaim>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetList().ToList());
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CityValidator), Priority = 1)]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Add(OperationClaim operationClaim)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimAdd);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.OperationClaimRemove);
        }

        [SecuredOperation("Admin")]
        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.OperationClaimUpdate);
        }

        [SecuredOperation("Admin")]
        public IResult TransactionalOperation(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimUpdate);
        }
    }
}
