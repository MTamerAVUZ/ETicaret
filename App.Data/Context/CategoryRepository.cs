using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class CategoryRepository :
	RepositoryBase<CategoryEntity>, ICategoryRepository
	{
		public CategoryRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<CategoryEntity> GetAllCategories(bool trackChanges) => FindAll(trackChanges);


		//interface
		public CategoryEntity? GetOneCategory(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
