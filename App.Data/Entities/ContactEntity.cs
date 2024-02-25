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
	public class ContactEntity:BaseObject
	{

    [Required(ErrorMessage ="{0} alanı boş bırakılamaz.. ")]
    [DisplayName("Ad Soyad")]
    [MinLength(2,ErrorMessage ="{0} {1} Karakterden kısa olamaz.. ")]
    [MaxLength(50,ErrorMessage ="{0} {1} Karakterden uzun olamaz... ")]
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
