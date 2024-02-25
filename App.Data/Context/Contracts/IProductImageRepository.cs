using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface IProductImageRepository : IRepositoryBase<ProductImageEntity>
	{
		public IEnumerable<ProductImageEntity> FindAll(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public ProductImageEntity? FindByCondition(Expression<Func<ProductImageEntity, bool>> expression, bool trackchanges)
		{
			throw new NotImplementedException();
		}
	}
}
