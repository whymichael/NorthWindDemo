using NorthwindWebApp.Models;
using NorthwindWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindWebApp.BusinessLayer
{
    public interface ICategoriesBL : IAutoInject
    {
        IEnumerable<Categories> GetAll();
        Categories Get(int? id);
        void Create(Categories catagory);
        void Update(Categories catagory);
        void Delete(int id);
    }
}
