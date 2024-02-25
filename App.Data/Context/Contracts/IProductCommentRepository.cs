using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface IProductCommentRepository : IRepositoryBase<ProductCommentEntity>
	{
		public IEnumerable<ProductCommentEntity> FindAll(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public ProductCommentEntity? FindByCondition(Expression<Func<ProductCommentEntity, bool>> expression, bool trackchanges)
		{
			throw new NotImplementedException();
		}
	}
}
