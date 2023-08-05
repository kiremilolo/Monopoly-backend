using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Base;

namespace Core.Entities.Product
{
    public class Collection : IBaseEntity
    {
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
