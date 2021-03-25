using System;
using System.Collections.Generic;

namespace MinhHungShop.Entities
{
    public partial class MenuType
    {
        public MenuType()
        {
            Menu = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Menu> Menu { get; set; }
    }
}
