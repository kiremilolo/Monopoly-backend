using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Base;

namespace Core.Entities.Product
{
    public class Product : IBaseEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public Classes classes { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public Collection Collection { get; set; }
        public string ImgUrl { get; set; }
    }
}
