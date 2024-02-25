using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface IContactRepository : IRepositoryBase<ContactEntity>
	{
		public IEnumerable<ContactEntity> FindAll(bool trackChanges)
		{
			throw new NotImplementedException();
		}

		public ContactEntity? FindByCondition(Expression<Func<ContactEntity, bool>> expression, bool trackchanges)
		{
			throw new NotImplementedException();
		}
	}
}
