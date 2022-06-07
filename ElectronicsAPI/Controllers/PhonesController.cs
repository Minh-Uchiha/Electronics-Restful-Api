using Azure.Storage.Blobs;
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
    public class PhonesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PhonesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Handle get request for phones with simplified information
        [HttpGet]
        public async Task<IActionResult> GetPhonesWithMinimalContent(int? PageNumber, int? PageSize)
        {
            var CurrPageNumber = PageNumber ?? 1;
            var CurrPageSize = PageSize ?? 5;
            var phones = await (from phone in _db.Phones
                           select new
                           {
                               Name = phone.Name,
                               Price = phone.Price,
                               Image = phone.ImageUrl,
                               Camera = phone.Camera,
                               BattetyLife = phone.BatteryLife
                           }
                           ).ToListAsync();
            return Ok(phones.Skip(CurrPageSize*(CurrPageNumber - 1)).Take(CurrPageSize));
        }

        // Handle get request for phones with detailed information
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPhonesDetails()
        {
            var phones = await _db.Phones.Include(a => a.CompatibleHeadphones).ToListAsync();
            return Ok(phones);
        }

        // // Handle get request for information of a phone given an Id
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPhoneById(int? Id)
        {
            if (Id == null) return BadRequest();
            var phone = await _db.Phones.Where(a => a.Id == Id).Include(a => a.CompatibleHeadphones).ToListAsync();
            return Ok(phone);
        }

        // Handle request to create a new phone
        [HttpPost]
        public async Task<IActionResult> CreateNewPhone([FromForm] Phone phone)
        {
            
            phone.ImageUrl = await Helpers.FileHelper.UploadPhoneImage(phone.Image);
            await _db.Phones.AddAsync(phone);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // Handle request to update a phone's information
        [HttpPut]
        public async Task<IActionResult> UpdatePhoneInfo([FromForm] Phone phone)
        {
            var updatedPhone = await _db.Phones.FindAsync(phone.Id);
            updatedPhone = phone;
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // Handle get request to get get all headphones that are compatible with a phone of a specific Id
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetAllCompatibleHeadphones(int? Id)
        {
            Phone phone = await _db.Phones.FindAsync(Id);
            ICollection<Headphone> keyboards = phone.CompatibleHeadphones.ToList();
            return Ok(keyboards);
        }

        // Handle Search request from client side (Search By Name)
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchByName(string? query) {
            if (query == null) return Ok(new List<Phone>());
            var phones = await (from phone in _db.Phones
                             where phone.Name.StartsWith(query)
                             select new
                             {
                                 Name = phone.Name,
                                 Price = phone.Price,
                                 Image = phone.ImageUrl,
                                 Camera = phone.Camera,
                                 BattetyLife = phone.BatteryLife
                             }
            ).ToListAsync();
            return Ok(phones);
        }

        // Handle Search request from client side (Search By Price)
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchByPriceRange(int? lowerBound, int? upperBound)
        {
            var currLowerBound = lowerBound ?? 5;
            var currUpperBound = upperBound ?? 10000;
            var phones = await (from phone in _db.Phones
                                 where (phone.Price >= currLowerBound && phone.Price <= currUpperBound)
                                 select new
                                 {
                                     Name = phone.Name,
                                     Price = phone.Price,
                                     Image = phone.ImageUrl,
                                     Camera = phone.Camera,
                                     BattetyLife = phone.BatteryLife
                                 }
            ).ToListAsync();
            return Ok(phones);
        }

    }
}
