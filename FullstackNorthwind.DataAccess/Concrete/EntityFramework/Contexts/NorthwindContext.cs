using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FullstackNorthwind.DataAccess.Concrete.EntityFramework.Contexts;
public class NorthwindContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(
			@"Data Source=AKINCENGIZ;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
	}

	public DbSet<Product> Products { get; set; }
	public DbSet<Category> Categories { get; set; }
}
