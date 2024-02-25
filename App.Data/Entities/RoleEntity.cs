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
   public class RoleEntity:BaseObject
   {
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz! ")]
    [DisplayName("Kullanıcı Rolü")]
      [MaxLength(10, ErrorMessage = "{0} {1} karakterden fazla olamaz")]
      [MinLength(2, ErrorMessage = "{0} {1} karakterden az olamaz. ")]
      public string Name { get; set; }



    public override bool Equals(object obj)
    {
      if (obj == null || GetType() != obj.GetType())
      {
        return false;
      }

      RoleEntity other = (RoleEntity)obj;
      return Id == other.Id && Name == other.Name;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Id, Name);
    }

  }
}
