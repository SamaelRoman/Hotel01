using Hotel01.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel01.BLL.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        IEnumerable<CategoryDTO> GetAllCategory();
    }
}
