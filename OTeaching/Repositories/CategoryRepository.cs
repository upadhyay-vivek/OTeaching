using OTeaching.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTeaching.Repositories
{
    public class CategoryRepository
    {
        private readonly OTeachingContext _oTeachingContext;
        public CategoryRepository()
        {
            _oTeachingContext = new OTeachingContext();
        }

        public List<Category> GetAllCategory()
        {
            return _oTeachingContext.Categories.ToList();
        }
    }
}