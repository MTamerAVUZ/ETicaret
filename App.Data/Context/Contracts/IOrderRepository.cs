using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface IOrderRepository : IRepositoryBase<OrderEntity>
	{
		public IEnumerable<OrderEntity> FindAll(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public OrderEntity? FindByCondition(Expression<Func<OrderEntity, bool>> expression, bool trackchanges)
		{
			throw new NotImplementedException();
		}
	}
}
