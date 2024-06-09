using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FullstackNorthwind.Business.Abstract;
using FullstackNorthwind.Business.Concrete;
using FullstackNorthwind.DataAccess.Abstract;
using FullstackNorthwind.DataAccess.Concrete.EntityFramework.Contexts;

namespace FullstackNorthwind.Business.DependencyResolvers.AutoFac;
public class AutofacBusinessModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
		builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
	}
}
