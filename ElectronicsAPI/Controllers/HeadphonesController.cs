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
    public class HeadphonesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public HeadphonesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Handle get request for headphone with simplified information
        [HttpGet]
        public async Task<IActionResult> GetLaptopsWithMinimalContent(int? PageNumber, int? PageSize)
        {
            var CurrPageNumber = PageNumber ?? 1;
            var CurrPageSize = PageSize ?? 5;
            var laptops = await (from headphone in _db.Headphones
                           select new
                           {
                               Id = headphone.Id,
                               Name = headphone.Name,
                               Color = headphone.Color,
                               BatteryLife = headphone.BatteryLife,
                               Price = headphone.Price,
                               Image = headphone.ImageUrl
                           }
                           ).ToListAsync();
            return Ok(laptops.Skip(CurrPageSize*(CurrPageNumber - 1)).Take(CurrPageSize));
        }

        // Handle get request for headphone with detailed information
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllHeadphonesDetails()
        {
            var headphones = await _db.Headphones.ToListAsync();
            return Ok(headphones);
        }

        // // Handle get request for information of a headphone given an Id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetHeadphoneById(int? Id)
        {
            if (Id == null) return BadRequest();
            Headphone headphone = await _db.Headphones.FindAsync(Id);
            return Ok(headphone);
        }

        // Handle request to create a new headphone
        [HttpPost]
        public async Task<IActionResult> CreateNewHeadphone([FromForm] Headphone headphone)
        {
            headphone.ImageUrl = await Helpers.FileHelper.UploadHeadphoneImage(headphone.Image);
            //var compatibleLaptopId = headphone.CompatibleWithLatop;*
            //var compatiblePhoneId = headphone.CompatibleWithPhone;
            //Laptop compatibleLaptop = await _db.Laptops.FindAsync(compatibleLaptopId);
            //Phone compatiblePhone = await _db.Phones.FindAsync(compatiblePhoneId);
            //compatibleLaptop.CompatibleHeadphones.Add(headphone);
            //compatiblePhone.CompatibleHeadphones.Add(headphone);
            await _db.AddAsync(headphone);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // Handle request to update a headphone's information
        [HttpPut]
        public async Task<IActionResult> UpdateHeadphoneInfo([FromForm] Headphone headphone)
        {
            var updatedHeadphone = await _db.Headphones.FindAsync(headphone.Id);
            updatedHeadphone = headphone;
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // Handle Search request from client side (Search By Name)
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchByName(string? query) {
            if (query == null) return Ok(new List<Laptop>());
            var headphones = await (from headphone in _db.Headphones
                             where headphone.Name.StartsWith(query)
                             select new
                             {
                                 Id = headphone.Id,
                                 Name = headphone.Name,
                                 Color = headphone.Color,
                                 BatteryLife = headphone.BatteryLife,
                                 Price = headphone.Price,
                                 Image = headphone.ImageUrl
                             }
            ).ToListAsync();
            return Ok(headphones);
        }

        // Handle Search request from client side (Search By Price)
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchByPriceRange(int? lowerBound, int? upperBound)
        {
            var currLowerBound = lowerBound ?? 5;
            var currUpperBound = upperBound ?? 10000;
            var headphones = await (from headphone in _db.Headphones
                                 where (headphone.Price >= currLowerBound && headphone.Price <= currUpperBound)
                                 select new
                                 {
                                     Id = headphone.Id,
                                     Name = headphone.Name,
                                     Color = headphone.Color,
                                     BatteryLife = headphone.BatteryLife,
                                     Price = headphone.Price,
                                     Image = headphone.ImageUrl
                                 }
            ).ToListAsync();
            return Ok(headphones);
        }

        // Haven't tested yet
        // Handle get request for headphones that are compatible with a specific phone
        [HttpGet("[action]")]
        public async Task<IActionResult> GetHeadphonesByCompatiblePhone(string? PhoneName)
        {
            var CompatiblePhoneName = PhoneName ?? "";
            var CompatiblePhone = await _db.Phones.FirstOrDefaultAsync(u => u.Name == CompatiblePhoneName);
            var headphones = await (from headphone in _db.Headphones
                             where headphone.PhoneId == CompatiblePhone.Id
                             select new
                             {
                                 Id = headphone.Id,
                                 Name = headphone.Name,
                                 Color = headphone.Color,
                                 BatteryLife = headphone.BatteryLife,
                                 Price = headphone.Price,
                                 Image = headphone.ImageUrl
                             }
            ).ToListAsync();
            return Ok(headphones);
        }

        // Haven't tested yet
        // Handle get request for headphones that are compatible with a specific laptop
        [HttpGet("[action]")]
        public async Task<IActionResult> GetHeadphonesByCompatibleLaptop (string? LaptopName)
        {
            var CompatibleLaptopName = LaptopName ?? "";
            var CompatibleLaptop = await _db.Laptops.FirstOrDefaultAsync(u => u.Name == CompatibleLaptopName);
            var headphones = await (from headphone in _db.Headphones
                                   where headphone.LaptopId == CompatibleLaptop.Id
                                   select new
                                   {
                                       Id = headphone.Id,
                                       Name = headphone.Name,
                                       Color = headphone.Color,
                                       BatteryLife = headphone.BatteryLife,
                                       Price = headphone.Price,
                                       Image = headphone.ImageUrl
                                   }
            ).ToListAsync();
            return Ok(headphones);
        }

    }
}
