using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TruphoneTest.Models;
using TruphoneTest.Services;

namespace TruphoneTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public DeviceController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ListDevices()
        {
            try
            {
                DeviceService service = new();
                return Ok(service.List());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex , "Error found!", DateTime.UtcNow.ToLongTimeString());
                return BadRequest();                
            }
        }

        [HttpGet("byid/{id}")]
        public IActionResult GetDevice(int id)
        {
            try
            {
                DeviceService service = new();
                var device = service.Get(id);
                if (device == null)
                    return NotFound(device);
                return Ok(device);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error found!", DateTime.UtcNow.ToLongTimeString());
                return BadRequest();
            }
        }

        [HttpGet("bybrand/{brand}")]
        public IActionResult GetDeviceByBrand(string brand)
        {
            try
            {
                DeviceService service = new();
                var devices = service.GetByBrand(brand);
                if (devices == null || devices.Count == 0)
                    return NotFound();
                return Ok(devices);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error found!", DateTime.UtcNow.ToLongTimeString());
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult AddDevice(Device device)
        {
            try
            {
                DeviceService service = new();
                service.Add(device);                
                return Ok();                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error found!", DateTime.UtcNow.ToLongTimeString());
                return BadRequest();                
            }
        }

        [HttpPost]
        public IActionResult UpdateDevice(Device device)
        {
            try
            {
                DeviceService service = new();
                var result = service.Update(device);
                if (result)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error found!", DateTime.UtcNow.ToLongTimeString());
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateDevice(int id, [FromBody] JsonPatchDocument<Device> jsonDevice)
        {
            try
            {
                DeviceService service = new();
                Device device = service.Get(id);
                jsonDevice.ApplyTo(device);
                var result = service.Update(device);
                if (result)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error found!", DateTime.UtcNow.ToLongTimeString());
                return BadRequest();
            }
        }
    }
}
