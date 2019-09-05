using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAMVC.Models
{
    public class RouteSignalR
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan StopTime { get; set; }
        public decimal Distance { get; set; }
        public int NumberOfCustomers { get; set; }
        public Driver Driver { get; set; }
        public bool AllDone { get; set; }
        public bool PickingDone { get; set; }
        public bool FreezerDone { get; set; }
        public int NumberOfFreezeBags { get; set; }
        public int NumberOfPickingBoxes { get; set; }
    }
}
