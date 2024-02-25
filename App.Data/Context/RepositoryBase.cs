using App.Data.Context.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new() 
	{

		protected readonly DatabaseContext _context; 

		protected RepositoryBase(DatabaseContext context)
		{
			_context = context;
		}

		public IEnumerable<T> FindAll(bool trackChanges)
		{
			return trackChanges
				? _context.Set<T>()
				: _context.Set<T>().AsNoTracking();
		}

		public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackchanges)
		{
			return trackchanges
				? _context.Set<T>().Where(expression).SingleOrDefault()
				: _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
		}
	}
}
