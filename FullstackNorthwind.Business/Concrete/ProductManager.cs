using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Business.Abstract;
using FullstackNorthwind.Business.Constants;
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
			return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList(),Messages.ProductGetListSuccess);
		}
		catch (Exception e)
		{
			return new ErrorDataResult<List<Product>>(Messages.ProductGetListError + "\n" + e.Message);
		}
	}

	public IDataResult<Product> GetById(int id)
	{
		try
		{
			return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id),Messages.ProductGetSuccess);
		}
		catch (Exception e)
		{
			return new ErrorDataResult<Product>(Messages.ProductGetError);
		}
	}

	public IResult Add(Product entity)
	{
		try
		{
			_productDal.Add(entity);
			return new SuccessResult(Messages.ProductAddedSuccess);
		}
		catch (Exception e)
		{
			return new ErrorResult(Messages.ProductAddedError);
		}
	}

	public IResult Update(Product entity)
	{
		try
		{
			_productDal.Update(entity);
			return new SuccessResult(Messages.ProductUpdatedSuccess);
		}
		catch (Exception e)
		{
			return new ErrorResult(Messages.ProductUpdatedError);
		}
	}

	public IResult Delete(Product entity)
	{
		try
		{
			_productDal.Delete(entity);
			return new SuccessResult(Messages.ProductDeletedSuccess);
		}
		catch (Exception e)
		{
			return new ErrorResult(Messages.ProductDeletedError + "\n" + e.Message);
		}
	}

	public IDataResult<List<Product>> GetProductsByCategory(int categoryId)
	{
		try
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId).ToList(),Messages.ProductGetListSuccess);
		}
		catch (Exception e)
		{
			return new ErrorDataResult<List<Product>>(Messages.ProductGetListError);
		}
	}
}
