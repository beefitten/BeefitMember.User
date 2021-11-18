using System.Collections.Generic;

namespace Domain.Services.FitnessPackage.FitnessPackageModels
{
    public class BookingsModel
    {
        public string TopPicPath { get; set; }
        public List<Bookings> Bookings { get; set; }
        public bool ShowLocation { get; set; }
    }
}