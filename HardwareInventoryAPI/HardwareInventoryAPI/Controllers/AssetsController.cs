using HardwareInventoryAPI.Data;
using HardwareInventoryAPI.models;
//using HardwareInventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HardwareInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssetsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/assets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
        {
            return await _context.Assets.ToListAsync();
        }

        // POST: api/assets
        [HttpPost]
        public async Task<ActionResult<Asset>> AddAsset(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return Ok(asset);
        }

        // PUT: api/assets/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsset(int id, Asset asset)
        {
            if (id != asset.AssetID)
            {
                return BadRequest();
            }

            _context.Entry(asset).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/assets/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            var asset = await _context.Assets.FindAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            _context.Assets.Remove(asset);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}