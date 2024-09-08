using RzdApi.Services.Implementations.GetTrainsDataService.Models;

namespace RzdApi.Services.Implementations.GetTrainsDirectionsService.Models
{
    public class Root
    {
        public List<City> city { get; set; }
        public List<TrainStation> train { get; set; }
        public List<Avium> avia { get; set; }
    }
}
