﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.DataAccess.EntityFramework;
using FullstackNorthwind.Core.Entities.Concrete;
using FullstackNorthwind.DataAccess.Abstract;
using FullstackNorthwind.DataAccess.Concrete.EntityFramework.Contexts;
using FullstackNorthwind.Entities.Concrete;

namespace FullstackNorthwind.DataAccess.Concrete.EntityFramework;
public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, NorthwindContext>, IOperationClaimDal
{
}
