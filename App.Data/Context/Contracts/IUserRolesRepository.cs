using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface IUserRolesRepository : IRepositoryBase<UserRolesEntity>
	{
		public IEnumerable<UserRolesEntity> FindAll(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public UserRolesEntity? FindByCondition(Expression<Func<UserRolesEntity, bool>> expression, bool trackchanges)
		{
			throw new NotImplementedException();
		}
	}
}
