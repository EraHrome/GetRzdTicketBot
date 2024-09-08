namespace RzdApi.Services.Implementations.GetTrainsPlacesDataService.Models
{
    public class GetTrainsPlacesDataRequest
    {
        /// <summary>
        /// Код города отправления. (например, для Сочи - это "2064130").
        /// </summary>
        public string OriginCode { get; set; } = null!;
        /// <summary>
        /// Код города прибытия. (например, для города "Ефремов" из Тульской области - это "2000250").
        /// </summary>
        public string DestinationCode { get; set; } = null!;
        /// <summary>
        /// Дата отправления в формате :"2024-09-08T00:00:00".
        /// </summary>
        public string DepartureDate { get; set; } = null!;
        /// <summary>
        /// Номер поезда.
        /// </summary>
        public string TrainNumber { get; set; } = null!;
        public bool OnlyFpkBranded { get; set; }
        public string Provider { get; set; } = null!;
        public string SpecialPlacesDemand { get; set; } = null!;

        public GetTrainsPlacesDataRequest(string originCode, string destinationCode, DateTime departureDate, string trainName)
        {
            OriginCode = originCode;
            DestinationCode = destinationCode;
            DepartureDate = departureDate.ToString("s");
            TrainNumber = trainName;

            OnlyFpkBranded = false;
            Provider = "p1";
            SpecialPlacesDemand = "standardplacesandfordisabledpersons";
        }
    }
}
