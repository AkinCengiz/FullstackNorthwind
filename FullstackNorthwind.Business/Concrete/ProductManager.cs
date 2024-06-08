using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Business.Abstract;
using FullstackNorthwind.DataAccess.Abstract;
using FullstackNorthwind.Entities.Concrete;

namespace FullstackNorthwind.Business.Concrete;
public class ProductManager : IProductService
{
	private IProductDal _productDal;

	public ProductManager(IProductDal productDal)
	{
		_productDal = productDal;
	}

	public List<Product> GetList()
	{
		return _productDal.GetAll().ToList();
	}

	public Product GetById(int id)
	{
		return _productDal.Get(p => p.ProductId == id);
	}

	public void Add(Product entity)
	{
		_productDal.Add(entity);
	}

	public void Update(Product entity)
	{
		_productDal.Update(entity);
	}

	public void Delete(Product entity)
	{
		_productDal.Delete(entity);
	}

	public List<Product> GetProductsByCategory(int categoryId)
	{
		return _productDal.GetAll(p => p.CategoryId == categoryId).ToList();
	}
}
