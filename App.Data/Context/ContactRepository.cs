using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class ContactRepository :
	RepositoryBase<ContactEntity>, IContactRepository
	{
		public ContactRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<ContactEntity> GetAllCMessages(bool trackChanges) => FindAll(trackChanges);


		//interface
		public ContactEntity? GetOneMessage(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
