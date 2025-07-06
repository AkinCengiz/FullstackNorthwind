using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.Entities.Concrete;

namespace FullstackNorthwind.Core.Utilities.Security.JwT;
public interface ITokenHelper
{
	AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
}
