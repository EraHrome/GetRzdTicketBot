namespace RzdApi.Services.Implementations.GetTrainsDirectionsService.Models
{
    public class GetTrainsDirectionsRequest
    {
        /// <summary>
        /// Например, "Сочи"
        /// </summary>
        public string Query { get; set; } = null!;
        public bool GroupResults { get; set; }
        public bool RailwaySortPriority { get; set; }
        public bool MergeSuburban { get; set; }
        public string Language { get; set; } = null!;
        public string TransportType { get; set; } = null!;

        public GetTrainsDirectionsRequest(string query)
        {
            Query = query;
            
            GroupResults = true;
            RailwaySortPriority = true;
            MergeSuburban = true;
            Language = "ru";
            TransportType = "rail,suburban,avia,boat,bus,aeroexpress";
        }
    }
}
