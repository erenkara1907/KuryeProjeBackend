using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Delivery:IEntity
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public long AddressId { get; set; }
        public string Status { get; set; }
        public string Vehicle { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}
