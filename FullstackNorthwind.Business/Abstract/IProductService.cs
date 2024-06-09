using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.Business;
using FullstackNorthwind.Core.Utilities.Results;
using FullstackNorthwind.Entities.Concrete;

namespace FullstackNorthwind.Business.Abstract;
public interface IProductService : IGenericService<Product>
{
	IDataResult<List<Product>> GetProductsByCategory(int categoryId);
}
