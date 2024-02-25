using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace e_Ticaret.Models.ViewModels
{
	public class AuthRegisterViewModel
	{
		[EmailAddress]
		[Required]
		public string Email { get; set; }

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[DisplayName("Kullanıcı Adı")]
		[MaxLength(50, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
		[MinLength(2, ErrorMessage = "{0} {1} karakterden az olamaz. ")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[DisplayName("Kullanıcı Soyadı")]
		[MaxLength(50, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
		[MinLength(2, ErrorMessage = "{0} {1} karakterden az olamaz. ")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
		[DisplayName("Kullanıcı Parolası")]
		[MinLength(1, ErrorMessage = "{0} {1} karakterden az olamaz. ")]
		public string Password { get; set; }
	}
}
