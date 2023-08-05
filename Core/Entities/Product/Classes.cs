using Core.Entities.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Product
{
    public class Classes : IBaseEntity
    {
        public int ClassesId { get; set; }
        public string Class { get; set; }
    }
}
