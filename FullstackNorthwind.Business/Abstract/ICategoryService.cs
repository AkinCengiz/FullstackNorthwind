using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.Business;
using FullstackNorthwind.Entities.Concrete;

namespace FullstackNorthwind.Business.Abstract;
public interface ICategoryService : IGenericService<Category>
{
}
