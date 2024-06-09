using FullstackNorthwind.Business.Abstract;
using FullstackNorthwind.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullstackNorthwind.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductsController(IProductService prodductService)
	{
		_productService = prodductService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var result = _productService.GetList();
		if (result.Success)
		{
			return Ok(result.Data);
		}
		return BadRequest(result.Message);
	}

	[HttpGet("{id}")]
	public IActionResult GetById(int id)
	{
		var result = _productService.GetById(id);
		if (result.Success)
		{
			return Ok(result.Data);
		}
		return BadRequest(result.Message);
	}

	[HttpGet("getbycategory")]
	public IActionResult GetProductsByCategory(int categoryId)
	{
		var result = _productService.GetProductsByCategory(categoryId);
		if (result.Success)
		{
			return Ok(result.Data);
		}
		return BadRequest(result.Message);
	}

	[HttpPost]
	public IActionResult Add(Product product)
	{
		var result = _productService.Add(product);
		if (result.Success)
		{
			return Ok(result.Message);
		}
		return BadRequest(result.Message);
	}

	[HttpPut]
	public IActionResult Update(Product product)
	{
		var result = _productService.Update(product);
		if (result.Success)
		{
			return Ok(result.Message);
		}
		return BadRequest(result.Message);
	}

	[HttpDelete]
	public IActionResult Delete(Product product)
	{
		var result = _productService.Delete(product);
		if (result.Success)
		{
			return Ok(result.Message);
		}
		return BadRequest(result.Message);
	}
}
