using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.DataAccess;
using FullstackNorthwind.Core.Entities.Concrete;
using FullstackNorthwind.Entities.Concrete;

namespace FullstackNorthwind.DataAccess.Abstract;
public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
{
}
