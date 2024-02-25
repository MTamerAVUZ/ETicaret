using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities.Base
{
   public class BaseObject
   {
      [Key]
      [Required]
      public int Id { get; set; }

      [Required]
      public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    }
}
