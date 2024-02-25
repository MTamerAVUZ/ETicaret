using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context.Contracts
{
	public interface IRepositoryManager
	{
		IProductRepository Product { get; }
		ICategoryRepository Category { get; }		
		ICartItemRepository CartItem { get; }
		IContactRepository Contact { get; }
		IOrderItemRepository OrderItem { get; }
		IOrderRepository Order { get; }
		IProductCommentRepository ProductComment { get; }
		IProductImageRepository ProductImage { get; }
		IRoleRepository Role { get; }
		IUserRepository User { get; }
		IUserRolesRepository UserRoles { get; }
		void Save();
	}
}
