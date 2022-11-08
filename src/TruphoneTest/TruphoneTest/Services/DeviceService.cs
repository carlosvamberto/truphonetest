using TruphoneTest.Models;

namespace TruphoneTest.Services
{
    public class DeviceService
    {
        /// <summary>
        /// Add device in database
        /// </summary>
        /// <param name="device"></param>
        public void Add(Device device)
        {
            Data
                .Database
                .Devices.Add(device);
        }

        /// <summary>
        /// Full update device in database
        /// </summary>
        /// <param name="device"></param>
        /// <returns>is true if found</returns>
        public bool Update(Device device)
        {
            Device? _device = Data
                .Database
                .Devices
                .Where(o => o.Id == device.Id)
                .FirstOrDefault();

            if (_device == null)
            {
                return false;
            }

            _device.DeviceName = device.DeviceName;
            _device.DeviceBrand = device.DeviceBrand;
            return true;
        }
        
        /// <summary>
        /// Remove device from database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>is true if found</returns>
        public bool Delete(int Id)
        {
            Device? _device = Data
                .Database
                .Devices
                .Where(o=> o.Id == Id)
                .FirstOrDefault();

            if (_device == null)
            {
                return false;
            }

            Data.Database.Devices.Remove(_device);
            return true;
        }

        /// <summary>
        /// Return all devices from database
        /// </summary>
        /// <returns></returns>
        public List<Device> List()
        {
            return Data.Database.Devices;
        }

        /// <summary>
        /// Return device by Id from database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Device? Get(int Id)
        {
            Device? device = Data
                .Database
                .Devices
                .Where(o => o.Id == Id)
                .FirstOrDefault();
                        
            return device;
        }

        /// <summary>
        /// Return all devices that contains brand name
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public List<Device> GetByBrand(string brand)
        {
            List<Device> device = Data
                .Database
                .Devices
                .Where(o => o.DeviceBrand.Contains(brand))
                .ToList();
            
            return device;
        }
    }
}
