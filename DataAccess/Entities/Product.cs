using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public long Id { get; set; } // auto create
        [Required(ErrorMessage ="Trường này không được bỏ trống")] 
        public string Name { get; set; }
        public string Code { get; set; } // auto create
        public string CodeColor { get; set; } // pick color and genarate hex code
        public string MetaTitle { get; set; } // auto set with name
        [Required(ErrorMessage = "Trường này không được bỏ trống")]
        public string Description { get; set; }  // shot description
        [Required(ErrorMessage = "Trường này không được bỏ trống")]
        public string Image { get; set; } // a box for upload image or chose link
        public string MoreImages { get; set; } // skip
        [Required(ErrorMessage = "Trường này không được bỏ trống")]
        public decimal? Price { get; set; } 
        public decimal? PromotionPrice { get; set; } // skip
        public bool? IncludeVat { get; set; } // skip // input check type and set checked status
        public int? Quantity { get; set; } // skip
        public long? ProducerId { get; set; } // select // id of Producer
        public long? CategoryId { get; set; } // select // id of category
        [Required(ErrorMessage = "Trường này không được bỏ trống")]
        public string Detail { get; set; } // detail
        public DateTime? CreatedDate { get; set; } // auto set
        public string CreatedBy { get; set; } // skip
        public DateTime? ModifiedDate { get; set; } // skip
        public string ModifiedBy { get; set; } // skip
        public bool? Status { get; set; } // skip
        public int? ViewCount { get; set; } // auto set 0 when create

        public ProductCategory Category { get; set; }
        public Producer Producer { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
