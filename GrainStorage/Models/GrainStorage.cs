using System;

namespace GrainStorageAPI.Models
{
    public class GrainStorageItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
