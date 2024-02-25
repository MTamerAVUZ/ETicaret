using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class UserRolesRepository : RepositoryBase<UserRolesEntity>, IUserRolesRepository
	{
		public UserRolesRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<UserRolesEntity> GetAllRoless(bool trackChanges) => FindAll(trackChanges);



		public UserRolesEntity? GetOneRoole(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
