using App.Data.Context.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly DatabaseContext _context;
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;		
		private readonly ICartItemRepository _cartItemRepository;
		private readonly IContactRepository _contactRepository;
		private readonly IOrderItemRepository _orderItemRepository;
		private readonly IOrderRepository _orderRepository;
		private readonly IProductCommentRepository _productCommentRepository;
		private readonly IProductImageRepository _productImageRepository;
		private readonly IRoleRepository _roleRepository;
		private readonly IUserRepository _userRepository;
		private readonly IUserRolesRepository _userRolesRepository;
		public RepositoryManager(IProductRepository productRepository,
			ICategoryRepository categoryRepository,
			DatabaseContext context,
			ICartItemRepository cartItemRepository,
			IContactRepository contactRepository,
			IOrderItemRepository orderItemRepository,
			IOrderRepository orderRepository,
			IProductCommentRepository productCommentRepository,
			IProductImageRepository productImageRepository,
			IRoleRepository roleRepository,
			IUserRepository userRepository,
			IUserRolesRepository userRolesRepository)
		{
			_categoryRepository = categoryRepository;
			_context = context;
			_productRepository = productRepository;
			_cartItemRepository = cartItemRepository;
			_contactRepository = contactRepository;
			_orderItemRepository = orderItemRepository;
			_orderRepository = orderRepository;
			_productCommentRepository = productCommentRepository;
			_productImageRepository = productImageRepository;
			_roleRepository = roleRepository;
			_userRepository = userRepository;
			_userRolesRepository = userRolesRepository;
		}

		public IProductRepository Product => _productRepository;

		public ICategoryRepository Category => _categoryRepository;

		public ICartItemRepository CartItem => _cartItemRepository;

		public IContactRepository Contact => _contactRepository;

		public IOrderItemRepository OrderItem => _orderItemRepository;

		public IOrderRepository Order => _orderRepository;

		public IProductCommentRepository ProductComment => _productCommentRepository;

		public IProductImageRepository ProductImage => _productImageRepository;

		public IRoleRepository Role => _roleRepository;

		public IUserRepository User => _userRepository;

		public IUserRolesRepository UserRoles => _userRolesRepository;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
