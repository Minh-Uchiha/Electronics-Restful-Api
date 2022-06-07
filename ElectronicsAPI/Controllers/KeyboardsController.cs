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
    public class KeyboardsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public KeyboardsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Handle get request for keyboard with simplified information
        [HttpGet]
        public async Task<IActionResult> GetKeyboardsWithMinimalContent(int? PageNumber, int? PageSize)
        {
            var CurrPageNumber = PageNumber ?? 1;
            var CurrPageSize = PageSize ?? 5;
            var keyboards = await (from keyboard in _db.Keyboards
                                   select new
                                   {
                                       Name = keyboard.Name,
                                       Price = keyboard.Price,
                                       Image = keyboard.ImageUrl,
                                       Type = keyboard.Type,
                                       hasRGB = keyboard.HasRGB
                                   }
                           ).ToListAsync();
            return Ok(keyboards.Skip(CurrPageSize * (CurrPageNumber - 1)).Take(CurrPageSize));
        }

        // Handle get request for keyboards with detailed information
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllKeyboardsDetails()
        {
            var keyboards = await _db.Keyboards.ToListAsync();
            return Ok(keyboards);
        }

        // // Handle get request for information of a keyboard given an Id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetKeyboardById(int? Id)
        {
            if (Id == null) return BadRequest();
            Keyboard keyboard = await _db.Keyboards.FindAsync(Id);
            return Ok(keyboard);
        }

        // Handle request to create a new keyboard
        [HttpPost]
        public async Task<IActionResult> CreateNewKeyboard([FromForm] Keyboard keyboard)
        {
            keyboard.ImageUrl = await Helpers.FileHelper.UploadKeyboardImage(keyboard.Image);
            //var compatibleLaptopId = keyboard.CompatibleWithLatop;
            //Laptop compatibleLaptop = await _db.Laptops.FindAsync(compatibleLaptopId);
            //compatibleLaptop.CompatibleKeyboards.Add(keyboard);
            await _db.AddAsync(keyboard);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // Handle request to update a keyboard's information
        [HttpPut]
        public async Task<IActionResult> UpdateKeyboardInfo([FromForm] Keyboard keyboard)
        {
            var updatedKeyboard = await _db.Keyboards.FindAsync(keyboard.Id);
            updatedKeyboard = keyboard;
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // Handle Search request from client side (Search By Name)
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchByName(string? query)
        {
            if (query == null) return Ok(new List<Laptop>());
            var keyboards = await (from keyboard in _db.Keyboards
                                   where keyboard.Name.StartsWith(query)
                                   select new
                                   {
                                       Name = keyboard.Name,
                                       Price = keyboard.Price,
                                       Image = keyboard.ImageUrl,
                                       Type = keyboard.Type,
                                       hasRGB = keyboard.HasRGB
                                   }
            ).ToListAsync();
            return Ok(keyboards);
        }

        // Handle Search request from client side (Search By Price)
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchByPriceRange(int? lowerBound, int? upperBound)
        {
            var currLowerBound = lowerBound ?? 5;
            var currUpperBound = upperBound ?? 10000;
            var keyboards = await (from keyboard in _db.Keyboards
                                   where (keyboard.Price >= lowerBound && keyboard.Price <= upperBound)
                                   select new
                                   {
                                       Name = keyboard.Name,
                                       Price = keyboard.Price,
                                       Image = keyboard.ImageUrl,
                                       Type = keyboard.Type,
                                       hasRGB = keyboard.HasRGB
                                   }
            ).ToListAsync();
            return Ok(keyboards);
        }

        // Haven't tested yet
        // Handle get request for keyboards that are compatible with a specific laptop
        [HttpGet("[action]")]
        public async Task<IActionResult> GetKeyboardsByCompatibleLaptop(string? LaptopName)
        {
            var CompatibleLaptopName = LaptopName ?? "";
            var CompatibleLaptop = await _db.Laptops.FirstOrDefaultAsync(u => u.Name == CompatibleLaptopName);
            var keyboards = await (from keyboard in _db.Keyboards
                                   where keyboard.LaptopId == CompatibleLaptop.Id
                                   select new
                                   {
                                       Name = keyboard.Name,
                                       Price = keyboard.Price,
                                       Image = keyboard.ImageUrl,
                                       Type = keyboard.Type,
                                       hasRGB = keyboard.HasRGB
                                   }
            ).ToListAsync();
            return Ok(keyboards);

        }
    }
}
