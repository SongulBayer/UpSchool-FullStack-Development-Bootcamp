using Domain.Common;
using Domain.Enums;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address:EntityBase<Guid>
    {
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public string District { get; set; }
        public string PostCode { get; set; }

        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }

        public AdressType AdressType { get; set; }


        //Bire çok ilişkisi oluşturuldu
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
