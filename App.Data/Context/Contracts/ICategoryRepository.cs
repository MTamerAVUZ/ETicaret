using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface ICategoryRepository : IRepositoryBase<CategoryEntity>
	{
		public IEnumerable<CategoryEntity> FindAll(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public CategoryEntity? FindByCondition(Expression<Func<CategoryEntity, bool>> expression, bool trackchanges)
		{
			throw new NotImplementedException();
		}
	}
}
