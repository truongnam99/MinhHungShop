using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class ProductView
    {
        [Required(ErrorMessage = "Trường này không được bỏ trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Trường này không được bỏ trống")]
        public string Description { get; set; }  // shot description
        public byte[] Image { get; set; } // a box for upload image or chose link
        [Required(ErrorMessage = "Trường này không được bỏ trống")]
        public decimal? Price { get; set; }
        public long? ProducerId { get; set; } // select // id of Producer
        public long? CategoryId { get; set; } // select // id of category
        [Required(ErrorMessage = "Trường này không được bỏ trống")]
        public string Detail { get; set; } // detail
    }
}
