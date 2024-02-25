using App.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
	public class UserRolesEntity:BaseObject
	{
		public int UserId { get; set; }
		public UserEntity User { get; set; }

		public int RoleId { get; set; }
		public RoleEntity Role { get; set; }
	}
}
