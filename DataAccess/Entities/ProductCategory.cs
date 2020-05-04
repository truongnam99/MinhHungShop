using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Product = new HashSet<Product>();
        }

        public long Id { get; set; }
        [Required(ErrorMessage ="Trường này không được bỏ trống")]
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public long? ParentId { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Status { get; set; }
        public bool? ShowOnHome { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
