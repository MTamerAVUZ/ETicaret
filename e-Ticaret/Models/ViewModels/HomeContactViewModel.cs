using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace e_Ticaret.Models.ViewModels
{
	public class HomeContactViewModel
	{
		[Required(ErrorMessage = "{0} alanı boş bırakılamaz.. ")]
		[DisplayName("Ad Soyad")]
		[MinLength(2, ErrorMessage = "{0} {1} Karakterden kısa olamaz.. ")]
		[MaxLength(50, ErrorMessage = "{0} {1} Karakterden uzun olamaz... ")]
		public string Issuer { get; set; }

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz.. ")]
		[DisplayName("Mail Adresi")]
		[EmailAddress]
		public string IssuerMail { get; set; }

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz.. ")]
		[DisplayName("Mesaj")]
		[MinLength(10, ErrorMessage = "{0} {1} Karakterden kısa olamaz.. ")]
		[MaxLength(500, ErrorMessage = "{0} {1} Karakterden uzun olamaz... ")]
		public string IssuerMessage { get; set; }
	}
}
