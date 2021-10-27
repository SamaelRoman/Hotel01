using Hotel01.DAL.Ef;
using Hotel01.DAL.Etities;
using Hotel01.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel01.DAL.Repositories
{
    public class CategoryInfoRepository : ICategoryInfoRepository
    {
        ContextDB contextDB;
        public CategoryInfoRepository(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }
        public void Create(CategoryInfo item)
        {
            contextDB.CategoryInfos.Add(item);
        }

        public void Delete(Guid ID)
        {
            CategoryInfo result = new CategoryInfo();
            result = contextDB.CategoryInfos.FirstOrDefault(B => B.ID == ID);
            if (result != null)
            {
                contextDB.CategoryInfos.Remove(result);
            }
        }

        public IEnumerable<CategoryInfo> Find(Func<CategoryInfo, bool> predicate)
        {
            List<CategoryInfo> result = new List<CategoryInfo>();
            result = contextDB.CategoryInfos.Where(predicate).ToList();
            return result;
        }

        public CategoryInfo Get(Guid ID)
        {
            CategoryInfo result = new CategoryInfo();
            result = contextDB.CategoryInfos.FirstOrDefault(B => B.ID == ID);
            return result;
        }

        public IEnumerable<CategoryInfo> GetAll()
        {
            List<CategoryInfo> result = new List<CategoryInfo>();
            result = contextDB.CategoryInfos.ToList();   
            return result;
        }

        public void Update(CategoryInfo Item)
        {
            contextDB.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
