using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class OrderRepository :
	RepositoryBase<OrderEntity>, IOrderRepository
	{
		public OrderRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<OrderEntity> GetAllOrders(bool trackChanges) => FindAll(trackChanges);



		public OrderEntity? GetOneOrder(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
