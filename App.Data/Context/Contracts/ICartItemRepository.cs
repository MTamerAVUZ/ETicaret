using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface ICartItemRepository : IRepositoryBase<CartItemEntity>
	{
		public IEnumerable<CartItemEntity> FindAll(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public CartItemEntity? FindByCondition(Expression<Func<CartItemEntity, bool>> expression, bool trackchanges)
		{
			throw new NotImplementedException();
		}
	}
}
