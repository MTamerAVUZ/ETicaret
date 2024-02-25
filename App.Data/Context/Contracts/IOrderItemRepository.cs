using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface IOrderItemRepository : IRepositoryBase<OrderItemEntity>
	{
		public IEnumerable<OrderItemEntity> FindAll(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public OrderItemEntity? FindByCondition(Expression<Func<OrderItemEntity, bool>> expression, bool trackchanges)
		{
			throw new NotImplementedException();
		}
	}
}
