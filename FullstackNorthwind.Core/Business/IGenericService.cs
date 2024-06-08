using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.Entities;

namespace FullstackNorthwind.Core.Business;
public interface IGenericService<T> where T : class, IEntity, new()
{
	List<T> GetList();
	T GetById(int id);
	void Add(T entity);
	void Update(T entity);
	void Delete(T entity);
}
