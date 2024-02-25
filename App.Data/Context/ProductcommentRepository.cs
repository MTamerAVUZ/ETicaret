using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class ProductCommentRepository :
	RepositoryBase<ProductCommentEntity>, IProductCommentRepository
	{
		public ProductCommentRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<ProductCommentEntity> GetAllComments(bool trackChanges) => FindAll(trackChanges);



		public ProductCommentEntity? GetOneComment(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
