using App.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
  public class ProductEntity : BaseObject
  {
    [Required]
    public int SellerId { get; set; }
    [ForeignKey("SellerId")]
    public virtual UserEntity User { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public virtual CategoryEntity Category { get; set; }

    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Ürün Adı")]
    [MaxLength(100, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
    [MinLength(2, ErrorMessage = "{0} {1} karakterden az olamaz. ")]
    public string Name { get; set; }


    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DataType(DataType.Currency)]
    [DisplayName("Ürün Fiyatı")]
    public decimal Price { get; set; }


    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Ürün Detayları")]
    [MaxLength(1000, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
    public string Details { get; set; }


    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Ürün Stok Sayısı")]
    public Byte StockAmount { get; set; }


    [Required]
    public bool Enabled { get; set; } = true;
  }
}
