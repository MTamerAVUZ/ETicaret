using App.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace e_Ticaret.Models.ViewModels
{
  public class ProductCreateViewModel
  {
		[Required(ErrorMessage = "Bir Satıcı Seçmelisiniz!! ")]
		[Range(1, 50, ErrorMessage = "Satıcı Seçiniz! ")]
		[ForeignKey("User")]
		public int SellerId { get; set; }

		//[ForeignKey("SellerId")]
		//public virtual UserEntity User { get; set; }

		[Required(ErrorMessage = "Bir Kategori Seçmelisiniz!! ")]
		[Range(1, 50, ErrorMessage = "Kategori Seçiniz! ")]
		[ForeignKey("Category")]
		public int CategoryId { get; set; }

		//[ForeignKey("CategoryId")]
		//public virtual CategoryEntity Category { get; set; }

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[Display(Name = "Ürün Adı")]
		[MaxLength(100, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
		[MinLength(2, ErrorMessage = "{0} {1} karakterden az olamaz. ")]
		public string Name { get; set; }

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[DataType(DataType.Currency)]
		[Display(Name = "Ürün Fiyatı")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[Display(Name = "Ürün Detayları")]
		[MaxLength(1000, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
		public string Details { get; set; }

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[Display(Name = "Ürün Stok Sayısı")]
		public byte StockAmount { get; set; }

	}
}
