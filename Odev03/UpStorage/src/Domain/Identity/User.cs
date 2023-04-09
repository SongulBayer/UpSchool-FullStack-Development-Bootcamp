﻿using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class User : IdentityUser<string>, ICreatedByEntity, IModifiedByEntity
    {
        public string FirstName  { get; set; }
        public string LastName  { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string? CreatedByUserId { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }

        //Bir userın kayıtlı birden çok adres bilgisi olabilir.
        public ICollection<Address> Adresses { get; set; }
    }
}
