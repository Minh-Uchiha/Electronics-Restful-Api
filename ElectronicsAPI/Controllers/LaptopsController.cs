using Electronics.DataAccess.Data;
using Electronics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ElectronicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public LaptopsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Handle get request for laptop with simplified information
        [HttpGet]
        public async Task<IActionResult> GetLaptopsWithMinimalContent(int? PageNumber, int? PageSize)
        {
            var CurrPageNumber = PageNumber ?? 1;
            var CurrPageSize = PageSize ?? 5;
            var laptops = await (from laptop in _db.Laptops
                           select new
                           {
                               Name = laptop.Name,
                               Size = laptop.Size,
                               Price = laptop.Price,
                               SSD = laptop.SSD,
                               HDD = laptop.HDD,
                               Image = laptop.ImageUrl
                           }
                           ).ToListAsync();
            return Ok(laptops.Skip(CurrPageSize*(CurrPageNumber - 1)).Take(CurrPageSize));
        }

        // Handle get request for laptop with detailed information
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLaptopsDetails()
        {
            var laptops = await _db.Laptops.Include(a => a.CompatibleHeadphones).Include(a => a.CompatibleKeyboards).ToListAsync();
            return Ok(laptops);
        }

        // // Handle get request for information of a laptop given an Id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetLaptopById(int? Id)
        {
            if (Id == null) return BadRequest();
            var laptop = await _db.Laptops.Where(a => a.Id == Id).Include(a => a.CompatibleHeadphones).Include(a => a.CompatibleKeyboards).ToListAsync();
            return Ok(laptop);
        }

        // Handle request to create a new laptop
        [HttpPost]
        public async Task<IActionResult> CreateNewLaptop([FromForm] Laptop laptop)
        {
            laptop.ImageUrl = await Helpers.FileHelper.UploadLaptopImage(laptop.Image);
            await _db.AddAsync(laptop);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // Handle request to update a laptop's information
        [HttpPut]
        public async Task<IActionResult> UpdateLaptopInfo([FromForm] Laptop laptop)
        {
            var updatedLaptop = await _db.Laptops.FindAsync(laptop.Id);
            updatedLaptop = laptop;
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // Handle get request to get get all keyboards that are compatible with a laptop of a specific Id
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetAllCompatibleKeyboards(int? Id)
        {
            Laptop laptop = await _db.Laptops.FindAsync(Id);
            ICollection<Keyboard> keyboards = laptop.CompatibleKeyboards.ToList(); 
            return Ok(keyboards);
        }

        // Handle get request to get get all headphones that are compatible with a laptop of a specific Id
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetAllCompatibleHeadphones(int? Id)
        {
            Laptop laptop = await _db.Laptops.FindAsync(Id);
            ICollection<Headphone> keyboards = laptop.CompatibleHeadphones.ToList();
            return Ok(keyboards);
        }

        // Handle Search request from client side (Search By Name)
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchByName(string? query) {
            if (query == null) return Ok(new List<Laptop>());
            var laptops = await (from laptop in _db.Laptops
                             where laptop.Name.StartsWith(query)
                             select new
                             {
                                 Name = laptop.Name,
                                 Size = laptop.Size,
                                 Price = laptop.Price,
                                 SSD = laptop.SSD,
                                 HDD = laptop.HDD,
                                 Image = laptop.ImageUrl
                             }
            ).ToListAsync();
            return Ok(laptops);
        }

        // Handle Search request from client side (Search By Price)
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchByPriceRange(int? lowerBound, int? upperBound)
        {
            var currLowerBound = lowerBound ?? 5;
            var currUpperBound = upperBound ?? 10000;
            var laptops = await (from laptop in _db.Laptops
                                 where (laptop.Price >= currLowerBound && laptop.Price <= currUpperBound)
                                 select new
                                 {
                                     Name = laptop.Name,
                                     Size = laptop.Size,
                                     Price = laptop.Price,
                                     SSD = laptop.SSD,
                                     HDD = laptop.HDD,
                                     Image = laptop.ImageUrl
                                 }
            ).ToListAsync();
            return Ok(laptops);
        }

    }
}
