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
   public class CartItemEntity:BaseObject
   {
      [Required]
        public int UserId { get; set; }

      public virtual UserEntity User{ get; set; }
      [Required]
      public int ProductId { get; set; }
      public virtual ProductEntity Product { get; set; }

    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Sepetteki ürün sayısı")]
      [MinLength(1,ErrorMessage ="{0} {1} adetten az olamaz")]
      public byte Quantity { get; set; }
    }
}
