using App.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Ticaret.Models.ViewModels
{
	public class ProductCommentViewModel
	{
				
		
		[Required]
		[ForeignKey("ProductEntity")]
		public int ProductId { get; set; }
		public virtual ProductEntity Product { get; set; }
		[Required]
		[ForeignKey("UserEntity")]
		public int UserId { get; set; }
		public virtual UserEntity User { get; set; }
		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[DisplayName("Ürün Yorumu")]
		[MaxLength(500, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
		[MinLength(2, ErrorMessage = "{0} {1} karakterden az olamaz. ")]
		public string Text { get; set; }
		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[DisplayName("Ürün Yıldız Sayısı")]
    [Range(1, 5, ErrorMessage = "{0} 1 ile 5 arasında olmalıdır")]
    public byte StarCount { get; set; }
		public List<ProductCommentEntity>? Comments { get; set; }
	}
}
