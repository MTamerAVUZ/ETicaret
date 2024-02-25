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
   public class OrderEntity:BaseObject
   {
      [Required]
        public int UserId { get; set; }
      public virtual UserEntity User{ get; set; }
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Sipariş Numarası")]
      [MinLength(2, ErrorMessage =("{0} {1} karakterden az olamaz"))]
      public string OrderCode { get; set; }
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Sipariş Adresi")]
      [MinLength(2, ErrorMessage = ("{0} {1} karakterden az olamaz"))]
      [MaxLength(250, ErrorMessage = ("{0} {1} karakterden fazla olamaz"))]
      public string Adress { get; set; }

    }
}
