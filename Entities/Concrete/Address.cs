using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Address:IEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CityId { get; set; }
        public long CountryId { get; set; }
        public string AddressDetail { get; set; }
        public int PostalCode { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}
