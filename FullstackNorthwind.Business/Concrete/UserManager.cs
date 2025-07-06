using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Business.Abstract;
using FullstackNorthwind.Business.Constants;
using FullstackNorthwind.Core.Entities.Concrete;
using FullstackNorthwind.Core.Utilities.Results;
using FullstackNorthwind.DataAccess.Abstract;
using FullstackNorthwind.Entities.Concrete;

namespace FullstackNorthwind.Business.Concrete;
public class UserManager : IUserService
{
	private readonly IUserDal _userDal;

	public UserManager(IUserDal userDal)
	{
		_userDal = userDal;
	}

	public IDataResult<List<User>> GetList()
	{
		try
		{
			return new SuccessDataResult<List<User>>(_userDal.GetAll().ToList(), Messages.UserGetListSuccess);
		}
		catch (Exception e)
		{
			return new ErrorDataResult<List<User>>(Messages.UserGetListError + "\n" + e.Message);
		}
		
	}

	public IDataResult<User> GetById(int id)
	{
		try
		{
			return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id), Messages.UserGetSuccess);
		}
		catch (Exception e)
		{
			return new ErrorDataResult<User>(Messages.UserGetError);
		}
	}

	public IResult Add(User entity)
	{
		try
		{
			_userDal.Add(entity);
			return new SuccessResult(Messages.UserAddedSuccess);
		}
		catch (Exception e)
		{
			return new ErrorResult(Messages.UserAddedError);
		}
	}

	public IResult Update(User entity)
	{
		try
		{
			_userDal.Update(entity);
			return new SuccessResult(Messages.UserUpdatedSuccess);
		}
		catch (Exception e)
		{
			return new ErrorResult(Messages.UserUpdatedError);
		}
	}

	public IResult Delete(User entity)
	{
		try
		{
			_userDal.Delete(entity);
			return new SuccessResult(Messages.UserDeletedSuccess);
		}
		catch (Exception e)
		{
			return new ErrorResult(Messages.UserDeletedError);
		}
	}

	public List<OperationClaim> GetClaims(User user)
	{
		try
		{
			return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.UserGetSuccess).Data;
		}
		catch (Exception e)
		{
			return new ErrorDataResult<List<OperationClaim>>(Messages.UserGetError + "\n" + e.Message).Data;
		}
	}

	public User GetByMail(string email)
	{
		try
		{
			return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email), Messages.UserGetSuccess).Data;
		}
		catch (Exception e)
		{
			return new ErrorDataResult<User>(Messages.UserGetError + "\n" + e.Message).Data;	
		}
	}
}
