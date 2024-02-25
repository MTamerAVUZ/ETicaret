using Microsoft.EntityFrameworkCore;

namespace Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}


		//Dbsetler gelecek






	}
}
