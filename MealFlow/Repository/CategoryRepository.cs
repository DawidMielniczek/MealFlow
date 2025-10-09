using MealFlow.Data;
using MealFlow.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MealFlow.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _db.Category.AddAsync(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Category.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(obj != null)
            {
                _db.Category.Remove(obj);
                return await _db.SaveChangesAsync() >0;
            }
            return false;
        }

        public async Task<Category> GetAsync(int id)
        {
            var obj = await _db.Category.Where(x => x.Id ==id).FirstOrDefaultAsync();
            if (obj != null)
                return obj;
            return new Category();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var obj = await _db.Category.Where(x => x.Id == category.Id).FirstOrDefaultAsync();
            if(obj is not null)
            {
                obj.Name = category.Name;
                _db.Category.Update(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            return new Category();
        }
    }
}
