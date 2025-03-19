using API_Project.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách sản phẩm
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCategory()
        {
            var data = await _context.Categories
                .Where(c => c.Id >= 12 && c.Id <= 16) // Lọc danh mục có ID từ 12 đến 16
                .Select(c => new
                {
                   c.Id,
                   c.Name,
                   c.ParentId,
                   c.IsShow,
                   c.IsBlog,
                   c.IsNew,
                   c.TopMenu

                }).ToListAsync();

            return Ok(data);
        }
    }
}
