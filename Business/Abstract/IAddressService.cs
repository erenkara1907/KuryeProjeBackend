using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IDataResult<Address> GetById(int addressId);
        IDataResult<List<Address>> GetList();
        IDataResult<List<Address>> GetListByUser(int userId);
        IResult Add(Address address);
        IResult Delete(Address address);
        IResult Update(Address address);

        IResult TransactionalOperation(Address address);
    }
}
