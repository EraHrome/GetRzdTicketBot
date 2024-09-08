namespace GetRzdTicketBot.Models
{
    public class SearchCitiesDTO : SearchCitiesCodesDTO
    {
        public string FromName { get; set; }
        public string ToName { get; set; }
    }
}
