namespace RzdApi.Services.Implementations.GetTrainsDataService.Models
{
    public class GetTrainsDataResponse
    {
        public string OriginStationCode { get; set; }
        public string DestinationStationCode { get; set; }
        public List<Train> Trains { get; set; }
        public object ClientFeeCalculation { get; set; }
        public object AgentFeeCalculation { get; set; }
        public string OriginCode { get; set; }
        public OriginStationInfo OriginStationInfo { get; set; }
        public int OriginTimeZoneDifference { get; set; }
        public string DestinationCode { get; set; }
        public DestinationStationInfo DestinationStationInfo { get; set; }
        public int DestinationTimeZoneDifference { get; set; }
        public string RoutePolicy { get; set; }
        public string DepartureTimeDescription { get; set; }
        public string ArrivalTimeDescription { get; set; }
        public bool IsFromUkrain { get; set; }
        public bool NotAllTrainsReturned { get; set; }
        public string BookingSystem { get; set; }
        public int Id { get; set; }
        public string DestinationStationName { get; set; }
        public string OriginStationName { get; set; }
        public DateTime MoscowDateTime { get; set; }
    }
}
