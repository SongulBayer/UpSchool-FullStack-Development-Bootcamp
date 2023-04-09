using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category:EntityBase<Guid>
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public ICollection<AccountCategory> AccountCategories { get; set; }

        //Bir kategoride birden fazka note bulunabilir
        //Çoka çok ilişkisi
        public ICollection<NoteCategory> NoteCategories { get; set; }
    }
}
