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
public class CategoryManager : ICategoryService
{
	private readonly ICategoryDal _categoryDal;

	public CategoryManager(ICategoryDal categoryDal)
	{
		_categoryDal = categoryDal;
	}

	public IDataResult<List<Category>> GetList()
	{
		try
		{
			return new SuccessDataResult<List<Category>>(_categoryDal.GetAll().ToList(),Messages.CategoryGetListSuccess);
		}
		catch (Exception e)
		{
			return new ErrorDataResult<List<Category>>(Messages.CategoryGetListError + "\n" + e.Message);
		}
	}

	public IDataResult<Category> GetById(int id)
	{
		try
		{
			return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == id),Messages.CategoryGetSuccess);
		}
		catch (Exception e)
		{
			return new ErrorDataResult<Category>(Messages.CategoryGetError);
		}
	}

	public IResult Add(Category entity)
	{
		try
		{
			_categoryDal.Add(entity);
			return new SuccessResult(Messages.CategoryAddedSuccess);
		}
		catch (Exception e)
		{
			return new ErrorResult(Messages.CategoryAddedError);
		}
	}

	public IResult Update(Category entity)
	{
		try
		{
			_categoryDal.Update(entity);
			return new SuccessResult(Messages.CategoryUpdatedSuccess);
		}
		catch (Exception e)
		{
			return new ErrorResult(Messages.CategoryUpdatedError);
		}
	}

	public IResult Delete(Category entity)
	{
		try
		{
			_categoryDal.Delete(entity);
			return new SuccessResult(Messages.CategoryDeletedSuccess);
		}
		catch (Exception e)
		{
			return new ErrorResult(Messages.CategoryDeletedError);
		}
	}
}
