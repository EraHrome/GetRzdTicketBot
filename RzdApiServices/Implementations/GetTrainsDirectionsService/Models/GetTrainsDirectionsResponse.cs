namespace RzdApi.Services.Implementations.GetTrainsDirectionsService.Models
{
    public class GetTrainsDirectionsResponse
    {
        public IEnumerable<City> City { get; set; }
        public IEnumerable<TrainStation> Train { get; set; }
        public IEnumerable<Avium> Avia { get; set; }
    }
}
