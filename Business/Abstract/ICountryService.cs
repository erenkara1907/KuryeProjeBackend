using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICountryService
    {
        IDataResult<Country> GetById(int countryId);
        IDataResult<List<Country>> GetList();
        IResult Add(Country country);
        IResult Delete(Country country);
        IResult Update(Country country);

        IResult TransactionalOperation(Country country);
    }
}
