using MealFlow.Data;
using MealFlow.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MealFlow.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _db.Product.AddAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(obj != null)
            {
                _db.Product.Remove(obj);
                return await _db.SaveChangesAsync() >0;
            }
            return false;
        }

        public async Task<Product> GetAsync(int id)
        {
            var obj = await _db.Product.Where(x => x.Id ==id).FirstOrDefaultAsync();
            if (obj != null)
                return obj;
            return new Product();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Product.ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var obj = await _db.Product.Where(x => x.Id == product.Id).FirstOrDefaultAsync();
            if(obj is not null)
            {
                obj.Name = product.Name;
                obj.Description = product.Description;
                obj.CategoryId = product.CategoryId;
                obj.Price = product.Price;
                _db.Product.Update(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            return new Product();
        }
    }
}
