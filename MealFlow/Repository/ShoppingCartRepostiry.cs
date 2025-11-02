using MealFlow.Data;
using MealFlow.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MealFlow.Repository
{
    public class ShoppingCartRepostiry : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartRepostiry(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ClearCartAsync(string? userId)
        {
            var cartItems = await _context.ShoppingCart.Where(u => u.UserId == userId).ToListAsync();
            _context.ShoppingCart.RemoveRange(cartItems);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ShoppingCart>> GetAllAsync(string? userId)
        {
            return await _context.ShoppingCart.Where(u => u.UserId == userId).Include(p => p.Product).ToListAsync();
        }

        public async Task<bool> UpdateCartAsync(string userId, int productId, int updateBy)
        {
            if(string.IsNullOrEmpty(userId))
            { 
                 return false;
            }
            var cart = await _context.ShoppingCart.FirstOrDefaultAsync(u=> u.UserId == userId && u.ProductId == productId);

            if(cart == null)
            {
                cart = new ShoppingCart
                {
                    UserId = userId,
                    ProductId = productId,
                    Count = updateBy
                };
                await _context.ShoppingCart.AddAsync(cart);
            }
            else
            {
                cart.Count += updateBy;
                if(cart.Count <= 0) {
                    _context.ShoppingCart.Remove(cart);
                }
            }
            return await _context.SaveChangesAsync() > 0 ;
        }
    }
}
