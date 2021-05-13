using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<City> GetById(int cityId);
        IDataResult<List<City>> GetList();
        IDataResult<List<City>> GetListByCountry(int countryId);
        IResult Add(City city);
        IResult Delete(City city);
        IResult Update(City city);

        IResult TransactionalOperation(City city);
    }
}
