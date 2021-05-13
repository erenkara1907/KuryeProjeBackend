using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IReceiverService
    {
        IDataResult<Receiver> GetById(int receiverId);
        IDataResult<List<Receiver>> GetList();
        IDataResult<List<Receiver>> GetListByDelivery(int deliveryId);
        IResult Add(Receiver receiver);
        IResult Delete(Receiver receiver);
        IResult Update(Receiver receiver);

        IResult TransactionalOperation(Receiver receiver);
    }
}
