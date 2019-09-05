using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAMVC.Models
{
    public class Route
    {
        public Route()
        {
            ListOfCoordinates = new List<Coordinate>();
            Driver = new Driver { Name=" " };
            Drivers = new List<Driver>();
        }
        public int Id { get; set; }
        public List<Coordinate> ListOfCoordinates { get; set; }
        public string RouteName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan StopTime { get; set; }
        public decimal Distance { get; set; }
        public int NumberOfCustomers { get; set; }
        public Driver Driver { get; set; }
        public List<Driver> Drivers { get; set; }
        public bool TruckLoaded { get; set; }
        public int NumberOfParcels { get; set; }
    }
}
