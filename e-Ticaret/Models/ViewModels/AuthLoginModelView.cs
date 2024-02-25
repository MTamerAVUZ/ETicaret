using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using App.Data.Entities;

namespace e_Ticaret.Models.ViewModels
{
	public class AuthLoginModelView
	{
		[EmailAddress]
		[DisplayName("Mail Adresi")]
		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		public string Email { get; set; }	

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[DisplayName("Kullanıcı Parolası")]
		[MinLength(1, ErrorMessage = "{0} {1} karakterden az olamaz. ")]
		public string Password { get; set; }
	
		//[DisplayName("Beni Hatırla")]
		//public bool RememberMe { get; set; }
	}
}

