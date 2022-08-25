using Contacts_List.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contacts_List.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        // GET: api/<CategoryController>
        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoryService.GetAllCategoryAsync();

            return Ok(result);
        }


    }
}
