using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Domain.Entities
{
    public class Entity<TKey>
    {
        public TKey Id { get; set; } = default!;
    }
}
