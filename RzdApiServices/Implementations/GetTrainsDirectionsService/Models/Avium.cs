namespace RzdApi.Services.Implementations.GetTrainsDirectionsService.Models
{
    /// <summary>
    /// Информация об аэропорте в городе.
    /// </summary>
    public class Avium
    {
        public string nodeId { get; set; }
        public string name { get; set; }
        public string nodeType { get; set; }
        public string transportType { get; set; }
        public string region { get; set; }
        public string regionIso { get; set; }
        public string countryIso { get; set; }
        public string aviaCode { get; set; }
        public bool hasAeroExpress { get; set; }
    }
}
