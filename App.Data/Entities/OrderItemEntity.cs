using App.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
   public class OrderItemEntity:BaseObject
   {
      [Required]
        public int OrderId { get; set; }
      public virtual OrderEntity Order { get; set; }
      [Required]
      public int ProductId { get; set; }
      public virtual ProductEntity Product { get; set; }
      [Required]
      [MinLength(1)]
      public byte Quantity { get; set; }
      [Required]
      [DataType(DataType.Currency)]
        public decimal UnitPrice{ get; set; }
    }
}
