
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
    public class CategoryRepository : ICategoryRepository
    {
        ContextDB contextDB;    
        public CategoryRepository(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }
        public void Create(Category item)
        {
            contextDB.Categories.Add(item);
        }

        public void Delete(Guid ID)
        {
            Category result = new Category();
            result = contextDB.Categories.FirstOrDefault(B => B.ID == ID);
            if (result != null)
            {
                contextDB.Categories.Remove(result);
            }
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            List<Category> result = new List<Category>();
            result = contextDB.Categories.Where(predicate).ToList();
            foreach (var C in result)
            {
                contextDB.Entry(C).Collection(NP => NP.CategoryInfos).Load();
                contextDB.Entry(C).Collection(NP => NP.Rooms).Load();
                foreach (var R in C.Rooms)
                {
                    contextDB.Entry(R).Collection(RI => RI.RoomImages).Load();
                }
                contextDB.Entry(C).Collection(NP => NP.Services).Load();
            }
            
            return result;
        }

        public Category Get(Guid ID)
        {
            Category result = new Category();
            result = contextDB.Categories.FirstOrDefault(B => B.ID == ID);
            contextDB.Entry(result).Collection(NP => NP.CategoryInfos).Load();
            contextDB.Entry(result).Collection(NP => NP.Rooms).Load();
            foreach (var R in result.Rooms)
            {
                contextDB.Entry(R).Collection(RI => RI.RoomImages).Load();
            }
            contextDB.Entry(result).Collection(NP => NP.Services).Load();
            return result;
        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> result = new List<Category>();
            result = contextDB.Categories.ToList();
            foreach (var C in result)
            {
                contextDB.Entry(C).Collection(NP => NP.CategoryInfos).Load();
                contextDB.Entry(C).Collection(NP => NP.Rooms).Load();
                foreach (var R in C.Rooms)
                {
                    contextDB.Entry(R).Collection(RI => RI.RoomImages).Load();
                }
                contextDB.Entry(C).Collection(NP => NP.Services).Load();
            }
            return result;
        }

        public void Update(Category Item)
        {
            contextDB.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
