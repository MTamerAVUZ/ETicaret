using App.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
   public class CategoryEntity:BaseObject
   {
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Kategori Adı")]
      [MinLength(2, ErrorMessage = ("{0} {1} karakterden az olamaz"))]
      [MaxLength(100, ErrorMessage = ("{0} {1} karakterden fazla olamaz"))]
      public string Name { get; set; }

    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Kategori Rengi")]
      [MinLength(3, ErrorMessage = ("{0} {1} karakterden az olamaz"))]
      [MaxLength(6, ErrorMessage = ("{0} {1} karakterden fazla olamaz"))]
      public string Color { get; set; }

    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Kategori İkonu ")]
      [MinLength(2, ErrorMessage = ("{0} {1} karakterden az olamaz"))]
      [MaxLength(50, ErrorMessage = ("{0} {1} karakterden fazla olamaz"))]
      public string IconCssClass { get; set; }

    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Kategori Tanımı ")]
    [MinLength(5, ErrorMessage = ("{0} {1} karakterden az olamaz"))]
    [MaxLength(50, ErrorMessage = ("{0} {1} karakterden fazla olamaz"))]
    public string Tanim { get; set; }

    }
}
