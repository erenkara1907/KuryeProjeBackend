﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetList();
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        User GetByMail(string email);
    }
}
