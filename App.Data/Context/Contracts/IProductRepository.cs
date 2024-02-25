using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface IProductRepository : IRepositoryBase<ProductEntity>
	{
		IEnumerable<ProductEntity> GetAllProducts(bool trackChanges);

		ProductEntity? GetOneProduct(int id, bool trackChanges);
	}
}
