using API_Project.Data;
using API_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        /// <summary>
        /// Lấy thông tin sản phẩm theo ID
        /// </summary>
        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            
            var query = _context.Products.Include(p => p.ImageProducs);
            // Tổng số sản phẩm
            int totalRecords = await query.CountAsync();
            // Lấy dữ liệu phân trang
            var data = await query
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.PosCode,
                    p.Description,
                    p.Price,
                    p.IsPublish,
                    p.Count,
                    Categories = p.Catefories.Select(c => new { c.Id, c.Name }),
                    Images = p.ImageProducs.Select(img => new
                    {
                        img.Image.Id,
                        img.Image.Name,
                        img.Image.Link,
                        img.Index,
                    })
                }).ToListAsync();

            return Ok(data);
        }

        /// <summary>
        /// Lấy thông tin sản phẩm theo ID
        /// </summary>
        [HttpGet("GetProductByCategory/{id}")]
        public async Task<IActionResult> GetProductByCategoryId(int id, int pagenumber = 1, int pagesize = 24)
        {
            try
            {
                
                if (pagenumber < 1) pagenumber = 1;
                if (pagesize < 1) pagesize = 20;

                // Lấy tổng số sản phẩm trong danh mục
                var totalProducts = await _context.Products
                    .Where(m => m.Catefories.Any(c => c.Id == id))
                    .CountAsync();

                if (totalProducts == 0)
                    return NotFound(new { message = "Không có sản phẩm nào trong danh mục này" });

                // Tính tổng số trang
                int totalPages = (int)Math.Ceiling((double)totalProducts / pagesize);

                // Lấy danh sách sản phẩm có phân trang
                var products = await _context.Products
                    .Include(m => m.ImageProducs)
                    .Include(m => m.Catefories)
                    .Where(m => m.Catefories.Any(c => c.Id == id))
                    .Select(m => new
                    {
                        m.Id,
                        m.Name,
                        m.Description,
                        m.Price,
                        Images = m.ImageProducs.Select(i => new { i.Image.Id, i.Image.Name, i.Image.Link }),
                        Categories = m.Catefories.Select(c => new { c.Id, c.Name })
                    })
                    .Skip((pagenumber - 1) * pagesize) // Bỏ qua các sản phẩm trước trang hiện tại
                    .Take(pagesize) // Lấy số lượng sản phẩm của trang hiện tại
                    .ToListAsync();

                return Ok(new
                {
                    PageNumber = pagenumber,
                    PageSize = pagesize,
                    TotalPages = totalPages,
                    TotalProducts = totalProducts,
                    Data = products
                });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }



        // Lấy danh sách sản phẩm
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProducts(int pagenumber = 1, int pagesize = 24)
        {
            if(pagenumber < 1) pagenumber = 1;
            if(pagesize < 1) pagesize = 20;
            var query = _context.Products.Include(p => p.ImageProducs);
            // Tổng số sản phẩm
            int totalRecords = await query.CountAsync();
            // Lấy dữ liệu phân trang
            var data = await query
                .OrderBy(p => p.Id)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.PosCode,
                    p.Description,
                    p.Price,
                    p.IsPublish,
                    p.Count,
                    Images = p.ImageProducs.Select(img => new 
                    {
                        img.Image.Id,
                        img.Image.Name,
                        img.Image.Link,
                        img.Index,
                    })
                }).ToListAsync();

            return Ok(new {
                TotalPages = (int)Math.Ceiling((double)totalRecords / pagesize),
                PageNumber = pagenumber,
                PageSize = pagesize,
                Data = data
            });
        }

        // Lấy danh sách sản phẩm mới nhất  
        [HttpGet("GetProductCreatedAt")]
        public async Task<IActionResult> GetProductsCreatedAt(int pagenumber = 1, int pagesize = 24)
        {
            if (pagenumber < 1) pagenumber = 1;
            if (pagesize < 1) pagesize = 20;
            var query = _context.Products.Include(p => p.ImageProducs);
            // Tổng số sản phẩm
            int totalRecords = await query.CountAsync();
            // Lấy dữ liệu phân trang
            var data = await query
                .OrderBy(p => p.Id)
                .OrderByDescending(p => p.CreatedAt ?? DateTime.MinValue) // sắp xếp từ mới đến củ 
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.PosCode,
                    p.Description,
                    p.Price,
                    p.IsPublish,
                    p.Count,
                    p.CreatedAt,
                    Images = p.ImageProducs.Select(img => new
                    {
                        img.Image.Id,
                        img.Image.Name,
                        img.Image.Link,
                        img.Index,
                    })
                }).ToListAsync();

            return Ok(new
            {
                TotalPages = (int)Math.Ceiling((double)totalRecords / pagesize),
                PageNumber = pagenumber,
                PageSize = pagesize,
                Data = data
            });
        }

        // Lấy danh sách sản phẩm củ nhất  
        [HttpGet("GetProductCreated")]
        public async Task<IActionResult> GetProductsCreated(int pagenumber = 1, int pagesize = 24)
        {
            if (pagenumber < 1) pagenumber = 1;
            if (pagesize < 1) pagesize = 20;
            var query = _context.Products.Include(p => p.ImageProducs);
            // Tổng số sản phẩm
            int totalRecords = await query.CountAsync();
            // Lấy dữ liệu phân trang
            var data = await query
                .OrderBy(p => p.CreatedAt ?? DateTime.MinValue) // Sắp xếp từ cũ đến mới
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.PosCode,
                    p.Description,
                    p.Price,
                    p.IsPublish,
                    p.Count,
                    p.CreatedAt,
                    Images = p.ImageProducs.Select(img => new
                    {
                        img.Image.Id,
                        img.Image.Name,
                        img.Image.Link,
                        img.Index,
                    })
                }).ToListAsync();

            return Ok(new
            {
                TotalPages = (int)Math.Ceiling((double)totalRecords / pagesize),
                PageNumber = pagenumber,
                PageSize = pagesize,
                Data = data
            });
        }

        // sắp xếp sản phẩm theo giá tăng dần 
        [HttpGet("GetProductASCPrice")]
        public async Task<IActionResult> GetProductsASCPrice(int pagenumber = 1, int pagesize = 24)
        {
            if (pagenumber < 1) pagenumber = 1;
            if (pagesize < 1) pagesize = 20;
            var query = _context.Products.Include(p => p.ImageProducs);
            // Tổng số sản phẩm
            int totalRecords = await query.CountAsync();
            // Lấy dữ liệu phân trang
            var data = await query
                .OrderBy(p => p.Price)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.PosCode,
                    p.Description,
                    p.Price,
                    p.IsPublish,
                    p.Count,
                    Images = p.ImageProducs.Select(img => new
                    {
                        img.Image.Id,
                        img.Image.Name,
                        img.Image.Link,
                        img.Index,
                    })
                }).ToListAsync();

            return Ok(new
            {
                TotalPages = (int)Math.Ceiling((double)totalRecords / pagesize),
                PageNumber = pagenumber,
                PageSize = pagesize,
                Data = data
            });
        }
        // sắp xếp sản phẩm theo giá giảm dần 
        [HttpGet("GetProductDESCPrice")]
        public async Task<IActionResult> GetProductsDESCPrice(int pagenumber = 1, int pagesize = 24)
        {
            if (pagenumber < 1) pagenumber = 1;
            if (pagesize < 1) pagesize = 20;
            var query = _context.Products.Include(p => p.ImageProducs);
            // Tổng số sản phẩm
            int totalRecords = await query.CountAsync();
            // Lấy dữ liệu phân trang
            var data = await query
                .OrderByDescending(p => p.Price)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.PosCode,
                    p.Description,
                    p.Price,
                    p.IsPublish,
                    p.Count,
                    Images = p.ImageProducs.Select(img => new
                    {
                        img.Image.Id,
                        img.Image.Name,
                        img.Image.Link,
                        img.Index,
                    })
                }).ToListAsync();

            return Ok(new
            {
                TotalPages = (int)Math.Ceiling((double)totalRecords / pagesize),
                PageNumber = pagenumber,
                PageSize = pagesize,
                Data = data
            });
        }
        //get color
        [HttpGet("GetColor")]
        public async Task<IActionResult> GetColor()
        {
            var data = await _context.Colors.ToListAsync();
            return Ok(data);
        }
        //get size 
        [HttpGet("GetSize")]
        public async Task<IActionResult> GetSize()
        {
            var data = await _context.Sizes.ToListAsync();
            return Ok(data);
        }
    }
}
