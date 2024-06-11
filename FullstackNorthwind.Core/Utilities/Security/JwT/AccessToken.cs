using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullstackNorthwind.Core.Utilities.Security.JwT;
public class AccessToken
{
	public string Token { get; set; }
	public DateTime Expiration { get; set; }
}
