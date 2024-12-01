using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GrainStorageAPI.Models;

namespace GrainStorageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrainStorageController : ControllerBase
    {
        private static readonly List<GrainStorageItem> Storages = new List<GrainStorageItem>
        {
            new GrainStorageItem { Id = 1, Type = "Wheat", Temperature = 22.5, Humidity = 55, LastUpdated = System.DateTime.Now },
            new GrainStorageItem { Id = 2, Type = "Corn", Temperature = 21.0, Humidity = 50, LastUpdated = System.DateTime.Now }
        };

        [HttpGet]
        public ActionResult<IEnumerable<GrainStorageItem>> GetAll()
        {
            return Ok(Storages);
        }

        [HttpGet("{id}")]
        public ActionResult<GrainStorageItem> GetById(int id)
        {
            var storage = Storages.Find(s => s.Id == id);
            if (storage == null)
            {
                return NotFound();
            }

            return Ok(storage);
        }

        [HttpPost]
        public ActionResult<GrainStorageItem> Create(GrainStorageItem storage)
        {
            storage.Id = Storages.Count + 1;
            Storages.Add(storage);
            return CreatedAtAction(nameof(GetById), new { id = storage.Id }, storage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, GrainStorageItem updatedStorage)
        {
            var storage = Storages.Find(s => s.Id == id);
            if (storage == null)
            {
                return NotFound();
            }

            storage.Type = updatedStorage.Type;
            storage.Temperature = updatedStorage.Temperature;
            storage.Humidity = updatedStorage.Humidity;
            storage.LastUpdated = System.DateTime.Now;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var storage = Storages.Find(s => s.Id == id);
            if (storage == null)
            {
                return NotFound();
            }

            Storages.Remove(storage);
            return NoContent();
        }
    }
}