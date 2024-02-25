using App.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
   public class ProductImageEntity:BaseObject
   {
      [Required]
        public int ProductId { get; set; }
      public virtual ProductEntity Product { get; set; }
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Ürün URL' si ")]
      [MaxLength(250, ErrorMessage ="{1} {0} karakterden fazla olamaz")]
      [MinLength(10,ErrorMessage ="{1} {0} karakterden az olamaz")]
      [DataType(DataType.Url)]
      public string Url { get; set; }
     
    }
}
