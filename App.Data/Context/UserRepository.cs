using App.Data.Context.Contracts;
using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
	{
		public UserRepository(DatabaseContext context) : base(context)
		{

		}

		public IEnumerable<UserEntity> GetAllUsers(bool trackChanges) => FindAll(trackChanges);



		public UserEntity? GetOneUser(int id, bool trackChanges)
		{
			return FindByCondition(p => p.Id.Equals(id), trackChanges);
		}

	}
}
