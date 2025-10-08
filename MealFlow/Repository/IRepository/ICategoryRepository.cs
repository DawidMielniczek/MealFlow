using MealFlow.Data;
using Microsoft.EntityFrameworkCore;

namespace MealFlow.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> Get(int id);
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category> Create(Category category);
        public Task<Category> Update(Category category);
        public Task<bool> Delete(int id);
    }
}
