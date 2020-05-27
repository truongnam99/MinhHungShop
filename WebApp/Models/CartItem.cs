using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [Serializable]
    public class CartItem
    {
        public long ProductId { get; set; }
        public  int Quantity { get; set; }
    }
}
