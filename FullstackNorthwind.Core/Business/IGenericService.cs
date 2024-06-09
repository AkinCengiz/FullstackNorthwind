using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.Entities;
using FullstackNorthwind.Core.Utilities.Results;

namespace FullstackNorthwind.Core.Business;
public interface IGenericService<T> where T : class, IEntity, new()
{
	IDataResult<List<T>> GetList();
	IDataResult<T> GetById(int id);
	IResult Add(T entity);
	IResult Update(T entity);
	IResult Delete(T entity);
}
