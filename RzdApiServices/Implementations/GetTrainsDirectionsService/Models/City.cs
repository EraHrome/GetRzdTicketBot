namespace RzdApi.Services.Implementations.GetTrainsDirectionsService.Models
{
    public class City
    {
        public string nodeId { get; set; }
        public string expressCode { get; set; }
        public string name { get; set; }
        public string nodeType { get; set; }
        public string transportType { get; set; }
        public string region { get; set; }
        public string regionIso { get; set; }
        public string countryIso { get; set; }
        public string aviaCode { get; set; }
        public string busCode { get; set; }
        public string suburbanCode { get; set; }
        public string foreignCode { get; set; }
        public string expressCodes { get; set; }
        public bool hasAeroExpress { get; set; }
    }
}
