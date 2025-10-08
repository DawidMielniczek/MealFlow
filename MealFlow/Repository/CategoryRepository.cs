using MealFlow.Data;
using MealFlow.Repository.IRepository;

namespace MealFlow.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category Create(Category category)
        {
            _db.Category.Add(category);
            _db.SaveChanges();
            return category;
        }

        public bool Delete(int id)
        {
            var obj = _db.Category.Where(x => x.Id == id).FirstOrDefault();
            if(obj != null)
            {
                _db.Category.Remove(obj);
                return _db.SaveChanges() >0;
            }
            return false;
        }

        public Category Get(int id)
        {
            var obj = _db.Category.Where(x => x.Id ==id).FirstOrDefault();
            if (obj != null)
                return new Category();
            return obj;
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Category.ToList();
        }

        public Category Update(Category category)
        {
            var obj = _db.Category.Where(x => x.Id == category.Id).FirstOrDefault();
            if(obj is not null)
            {
                obj.Name = category.Name;
                _db.Category.Update(obj);
                _db.SaveChanges();
                return obj;
            }
            return new Category();
        }
    }
}
