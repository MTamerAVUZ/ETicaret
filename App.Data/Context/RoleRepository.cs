using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class RoleRepository : RepositoryBase<RoleEntity>, IRoleRepository
	{
		public RoleRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<RoleEntity> GetAllRoles(bool trackChanges) => FindAll(trackChanges);



		public RoleEntity? GetOneRole(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
