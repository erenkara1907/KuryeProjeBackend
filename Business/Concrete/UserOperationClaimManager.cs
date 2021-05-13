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
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        [SecuredOperation("Admin")]
        public IDataResult<UserOperationClaim> GetById(int userOperationClaimId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == userOperationClaimId));
        }

        [SecuredOperation("Admin")]
        [PerformanceAspect(5)]
        public IDataResult<List<UserOperationClaim>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetList().ToList());
        }

        [SecuredOperation("Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<UserOperationClaim>> GetListByUser(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetList(u => u.UserId == userId).ToList());
        }

        [SecuredOperation("Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<UserOperationClaim>> GetListByOperationClaim(int operataionClaimId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetList(u => u.OperationClaimId == operataionClaimId).ToList());
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CityValidator), Priority = 1)]
        [CacheRemoveAspect("IUserOperationClaimService.Get")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdd);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimRemove);
        }

        [SecuredOperation("Admin")]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdate);
        }

        [SecuredOperation("Admin")]
        public IResult TransactionalOperation(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdate);
        }
    }
}
