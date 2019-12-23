using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProviderId { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
