using System.Collections.Generic;
using Domain.Services.FitnessPackage.FitnessPackageModels;
using Persistence.Models.FitnessPackage;

namespace Domain.Services.FitnessPackage
{
    public class FitnessPackageReturnModel
    {
        public string Name { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string ThirdColor { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderRadius { get; set; }
        public string Elevation { get; set; }
        public string Logo { get; set; }
        public List<Features> Features { get; set; }
        public OverViewModel OverView { get; set; }
        public WeightGoalModel WeightGoal { get; set; }
        public CenterInformationModel CenterInformation { get; set; }
        public MoreModel More { get; set; }
        public FontModel Font { get; set; }
        public BookingsModel Bookings { get; set; }
    }
}