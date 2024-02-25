using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface IUserRepository : IRepositoryBase<UserEntity>
	{
		public IEnumerable<UserEntity> FindAll(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public UserEntity? FindByCondition(Expression<Func<UserEntity, bool>> expression, bool trackchanges)
		{
			throw new NotImplementedException();
		}
	}
}
