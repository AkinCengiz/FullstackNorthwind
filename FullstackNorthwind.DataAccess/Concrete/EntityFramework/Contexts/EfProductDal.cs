using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.DataAccess.EntityFramework;
using FullstackNorthwind.DataAccess.Abstract;
using FullstackNorthwind.Entities.Concrete;

namespace FullstackNorthwind.DataAccess.Concrete.EntityFramework.Contexts;
public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
{
}
