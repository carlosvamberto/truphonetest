using TruphoneTest.Models;

namespace TruphoneTest.Data
{
    public class Database
    {
        public static List<Device> Devices { get; set; } = new List<Device>()
        {
            new Device() { Id = 1, DeviceName = "TV", DeviceBrand = "Sony", CreationTime = DateTime.Now },
            new Device() { Id = 2, DeviceName = "TV", DeviceBrand = "Samsung", CreationTime = DateTime.Now }
        };
    }
}
