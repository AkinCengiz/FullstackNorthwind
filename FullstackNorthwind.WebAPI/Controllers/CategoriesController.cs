using FullstackNorthwind.Business.Abstract;
using FullstackNorthwind.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullstackNorthwind.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
	private readonly ICategoryService _categoryService;

	public CategoriesController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	[HttpGet]
	public IActionResult GetList()
	{
		var result = _categoryService.GetList();
		if (result.Success)
		{
			return Ok(result.Data);
		}
		return BadRequest(result.Message);
	}

	[HttpGet("{id}")]
	public IActionResult GetById(int id)
	{
		var result = _categoryService.GetById(id);
		if (result.Success)
		{
			return Ok(result.Data);
		}
		return BadRequest(result.Message);
	}

	[HttpPost]
	public IActionResult Add(Category category)
	{
		var result = _categoryService.Add(category);
		if (result.Success)
		{
			return Ok(result.Message);
		}
		return BadRequest(result.Message);
	}

	[HttpPut]
	public IActionResult Update(Category category)
	{
		var result = _categoryService.Update(category);
		if (result.Success)
		{
			return Ok(result.Message);
		}
		return BadRequest(result.Message);
	}

	[HttpDelete]
	public IActionResult Delete(Category category)
	{
		var result = _categoryService.Delete(category);
		if (result.Success)
		{
			return Ok(result.Message);
		}
		return BadRequest(result.Message);
	}
}
