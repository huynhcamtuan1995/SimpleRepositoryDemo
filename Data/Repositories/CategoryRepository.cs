﻿using DataSql.EF;
using DataSql.Generic;
using DataSql.Models;
using DataSql.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace DataSql.Repositories
{
    public interface ICategoryRepository : IGeneric<Category>
    {
        IEnumerable<Category> GetAll();
        IEnumerable<object> GetAllSelect();
    }
    public class CategoryRepository : BaseGeneric<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext db) : base(db) { }

        public IEnumerable<Category> GetAll() => Query(includes: c => c.Products).ToList();
        public IEnumerable<object> GetAllSelect()
        {
            return Query<object>(select: a => new
            {
                ID = a.ID,
                Name = a.Name,
                Products = a.Products.Select(b => b.ID).ToList()
            }, includes: c => c.Products).ToPageList();
        }
    }
}
