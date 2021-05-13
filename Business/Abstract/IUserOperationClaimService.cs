using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<UserOperationClaim> GetById(int userOperationClaimId);
        IDataResult<List<UserOperationClaim>> GetList();
        IDataResult<List<UserOperationClaim>> GetListByUser(int userId);
        IDataResult<List<UserOperationClaim>> GetListByOperationClaim(int operataionClaimId);
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);

        IResult TransactionalOperation(UserOperationClaim userOperationClaim);
    }
}
