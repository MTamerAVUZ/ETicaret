using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class CartItemRepository :
	RepositoryBase<CartItemEntity>, ICartItemRepository
	{
		public CartItemRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<CartItemEntity> GetAllCartItems(bool trackChanges) => FindAll(trackChanges);


		//interface
		public CartItemEntity? GetOneCartItem(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
