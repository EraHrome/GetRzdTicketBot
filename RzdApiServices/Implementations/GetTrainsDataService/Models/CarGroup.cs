namespace RzdApi.Services.Implementations.GetTrainsDataService.Models
{
    public class CarGroup
    {
        public List<string> Carriers { get; set; }
        public List<string> CarrierDisplayNames { get; set; }
        public List<string> ServiceClasses { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public string CarType { get; set; }
        public string CarTypeName { get; set; }
        public int PlaceQuantity { get; set; }
        public int LowerPlaceQuantity { get; set; }
        public int UpperPlaceQuantity { get; set; }
        public int LowerSidePlaceQuantity { get; set; }
        public int UpperSidePlaceQuantity { get; set; }
        public int MalePlaceQuantity { get; set; }
        public int FemalePlaceQuantity { get; set; }
        public int EmptyCabinQuantity { get; set; }
        public int MixedCabinQuantity { get; set; }
        public bool IsSaleForbidden { get; set; }
        public string AvailabilityIndication { get; set; }
        public List<string> CarDescriptions { get; set; }
        public object ServiceClassNameRu { get; set; }
        public object ServiceClassNameEn { get; set; }
        public List<string> InternationalServiceClasses { get; set; }
        public List<double> ServiceCosts { get; set; }
        public bool IsBeddingSelectionPossible { get; set; }
        public List<string> BoardingSystemTypes { get; set; }
        public bool HasElectronicRegistration { get; set; }
        public bool HasGenderCabins { get; set; }
        public bool HasPlaceNumeration { get; set; }
        public bool HasPlacesNearPlayground { get; set; }
        public bool HasPlacesNearPets { get; set; }
        public bool HasPlacesForDisabledPersons { get; set; }
        public bool HasPlacesNearBabies { get; set; }
        public List<AvailableBaggageType> AvailableBaggageTypes { get; set; }
        public bool HasNonRefundableTariff { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<object> AllowedTariffs { get; set; }
        public string InfoRequestSchema { get; set; }
        public int TotalPlaceQuantity { get; set; }
        public List<string> PlaceReservationTypes { get; set; }
        public bool IsThreeHoursReservationAvailable { get; set; }
        public bool IsMealOptionPossible { get; set; }
        public bool IsAdditionalMealOptionPossible { get; set; }
        public bool IsOnRequestMealOptionPossible { get; set; }
        public bool IsTransitDocumentRequired { get; set; }
        public bool IsInterstate { get; set; }
        public object ClientFeeCalculation { get; set; }
        public object AgentFeeCalculation { get; set; }
        public bool HasNonBrandedCars { get; set; }
        public int TripPointQuantity { get; set; }
        public bool HasPlacesForBusinessTravelBooking { get; set; }
        public bool IsCarTransportationCoaches { get; set; }
        public object IsGroupTransportaionAvailable { get; set; }
        public string ServiceClassName { get; set; }
        public bool HasFssBenefit { get; set; }
    }
}
