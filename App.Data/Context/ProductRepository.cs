using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
	{
		public ProductRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<ProductEntity> GetAllProducts(bool trackChanges) => FindAll(trackChanges);



		public ProductEntity? GetOneProduct(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
