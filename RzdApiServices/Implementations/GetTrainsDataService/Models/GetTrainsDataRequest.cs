namespace RzdApi.Services.Implementations.GetTrainsDataService.Models
{
    public class GetTrainsDataRequest
    {
        /// <summary>
        /// Код города отправления. (например, для Сочи - это "2064130").
        /// </summary>
        public string Origin { get; set; } = null!;
        /// <summary>
        /// Код города прибытия. (например, для города "Ефремов" из Тульской области - это "2000250").
        /// </summary>
        public string Destination { get; set; } = null!;
        /// <summary>
        /// Дата отправления в формате :"2024-09-08T00:00:00".
        /// </summary>
        public string DepartureDate { get; set; } = null!;
        /// <summary>
        /// Время отбытия (по дефолту - 0).
        /// </summary>
        public int TimeFrom { get; set; }
        /// <summary>
        /// Время прибытия (по дефолту - 24).
        /// </summary>
        public int TimeTo { get; set; }
        /// <summary>
        /// Информация об использовании особых мест в фильтре.
        /// </summary>
        public string SpecialPlacesDemand { get; set; } = null!;
        public string CarGrouping { get; set; } = null!;
        public bool GetByLocalTime { get; set; }
        public string CarIssuingType { get; set; } = null!;
        public bool GetTrainsFromSchedule { get; set; }

        public GetTrainsDataRequest(string origin, string destination, DateTime departureDate)
        {
            Origin = origin;
            Destination = destination;
            DepartureDate = departureDate.ToString("s");

            GetTrainsFromSchedule = true;
            CarGrouping = "DontGroup";
            CarIssuingType = "All";
            GetByLocalTime = true;
            SpecialPlacesDemand = "StandardPlacesAndForDisabledPersons";
            TimeFrom = 0;
            TimeTo = 24;
        }
    }
}
