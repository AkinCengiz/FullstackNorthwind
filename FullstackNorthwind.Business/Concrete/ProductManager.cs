using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Business.Abstract;
using FullstackNorthwind.Core.Utilities.Results;
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

	public IDataResult<List<Product>> GetList()
	{
		try
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList());
		}
		catch (Exception e)
		{
			return new ErrorDataResult<List<Product>>(e.Message);
		}
	}

	public IDataResult<Product> GetById(int id)
	{
		try
		{
			return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
		}
		catch (Exception e)
		{
			return new ErrorDataResult<Product>(e.Message);
		}
	}

	public IResult Add(Product entity)
	{
		try
		{
			_productDal.Add(entity);
			return new SuccessResult();
		}
		catch (Exception e)
		{
			return new ErrorResult(e.Message);
		}
	}

	public IResult Update(Product entity)
	{
		try
		{
			_productDal.Update(entity);
			return new SuccessResult();
		}
		catch (Exception e)
		{
			return new ErrorResult(e.Message);
		}
	}

	public IResult Delete(Product entity)
	{
		try
		{
			_productDal.Delete(entity);
			return new SuccessResult();
		}
		catch (Exception e)
		{
			return new ErrorResult(e.Message);
		}
	}

	public IDataResult<List<Product>> GetProductsByCategory(int categoryId)
	{
		try
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId).ToList());
		}
		catch (Exception e)
		{
			return new ErrorDataResult<List<Product>>(e.Message);
		}
	}
}
