using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class ProductImageRepository :
	RepositoryBase<ProductImageEntity>, IProductImageRepository
	{
		public ProductImageRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<ProductImageEntity> GetAllPictures(bool trackChanges) => FindAll(trackChanges);



		public ProductImageEntity? GetOnePicture(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
