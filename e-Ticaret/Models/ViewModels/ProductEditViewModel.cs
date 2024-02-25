using App.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace e_Ticaret.Models.ViewModels
{
	public class ProductEditViewModel
	{
		[Required]
		[ForeignKey("User")]
		public int SellerId { get; set; }
		
		//public virtual UserEntity User { get; set; }
		[Required]
		[ForeignKey("Category")]
		public int CategoryId { get; set; }
		//public virtual CategoryEntity Category { get; set; }

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[DisplayName("Ürün Adı")]
		[MaxLength(100, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
		[MinLength(2, ErrorMessage = "{0} {1} karakterden az olamaz. ")]
		public string Name { get; set; }
		[Required]
		[DataType(DataType.Currency)]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[DisplayName("Ürün Detayları")]
		[MaxLength(1000, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
		public string Details { get; set; }
		[Required]
		public Byte StockAmount { get; set; }
		[Required]
		[Range(typeof(bool), "false", "true", ErrorMessage = "Ya Aktif Yada Pasif Seçilmeli !!!")]
		public bool Enabled { get; set; } = true;
	}
}
