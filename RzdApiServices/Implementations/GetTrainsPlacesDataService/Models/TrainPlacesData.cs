namespace RzdApi.Services.Implementations.GetTrainsPlacesDataService.Models
{
    public class TrainPlacesData
    {
        public string ServiceClass { get; set; }
        public string CarPlaceType { get; set; }
        public string CarPlaceName { get; set; }
        public bool IsForDisabledPersons { get; set; }
        public int PlaceQuantity { get; set; }
        //Compartment - купе
        //Luxury - СВ
        public string CarType { get; set; }
        public double MinPrice { get; set; }
    }
}
