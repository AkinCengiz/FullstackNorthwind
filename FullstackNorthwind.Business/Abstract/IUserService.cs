using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.Business;
using FullstackNorthwind.Core.Entities.Concrete;
using FullstackNorthwind.Entities.Concrete;

namespace FullstackNorthwind.Business.Abstract;
public interface IUserService : IGenericService<User>
{
	List<OperationClaim> GetClaims(User user);
	User GetByMail(string email);
}
