﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullstackNorthwind.Core.Entities;

namespace FullstackNorthwind.Entities.Concrete;

public class Category : IEntity
{
	public int CategoryId { get; set; }
	public string CategoryName { get; set; }
	public string Description { get; set; }
	//public byte[]? Picture { get; set; }
}
