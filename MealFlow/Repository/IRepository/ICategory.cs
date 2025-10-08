using MealFlow.Data;
using Microsoft.EntityFrameworkCore;

namespace MealFlow.Repository.IRepository
{
    public interface ICategory
    {
        public Category Get(int id);
        public IEnumerable<Category> GetAll();
        public Category Create(Category category);
        public Category Update(Category category);
        public bool Delete(int id);
    }
}
