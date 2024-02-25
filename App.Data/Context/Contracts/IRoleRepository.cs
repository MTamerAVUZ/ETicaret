using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface IRoleRepository : IRepositoryBase<RoleEntity>
	{
		public IEnumerable<RoleEntity> FindAll(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public RoleEntity? FindByCondition(Expression<Func<RoleEntity, bool>> expression, bool trackchanges)
		{
			throw new NotImplementedException();
		}
	}
}
