using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class OrderItemRepository :
	RepositoryBase<OrderItemEntity>, IOrderItemRepository
	{
		public OrderItemRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<OrderItemEntity> GetAllOrders(bool trackChanges) => FindAll(trackChanges);


		
		public OrderItemEntity? GetOneOrder(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
