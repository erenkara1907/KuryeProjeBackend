using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IDeliveryService
    {
        IDataResult<Delivery> GetById(int deliveryId);
        IDataResult<List<Delivery>> GetList();
        IDataResult<List<Delivery>> GetListByProduct(int productId);
        IResult Add(Delivery delivery);
        IResult Delete(Delivery delivery);
        IResult Update(Delivery delivery);

        IResult TransactionalOperation(Delivery delivery);
    }
}
