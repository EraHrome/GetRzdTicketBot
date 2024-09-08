using RzdApi.Services.Implementations.GetTrainsDirectionsService.Models;
using RzdApi.Services.Interfaces;
using System.Collections.Specialized;
using System.Net.Http.Json;
using System.Web;

namespace RzdApi.Services.Implementations.GetTrainsDirectionsService
{
    /// <summary>
    /// Получить информацию о городах, жд станциях и аэропортах по строковому запросу.
    /// </summary>
    public class GetTrainsDirectionsService : IGetDataService<GetTrainsDirectionsRequest, GetTrainsDirectionsResponse>
    {
        private static string _requestUrl = "https://ticket.rzd.ru/api/v1/suggests/";

        public async Task<GetTrainsDirectionsResponse> GetData(GetTrainsDirectionsRequest request)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(_requestUrl);
            queryString.Add("GroupResults", request.GroupResults.ToString());
            queryString.Add("RailwaySortPriority", request.RailwaySortPriority.ToString());
            queryString.Add("MergeSuburban", request.MergeSuburban.ToString());
            queryString.Add("Query", request.Query);
            queryString.Add("Language", request.Language);
            queryString.Add("TransportType", request.TransportType);
            var uriBuilder = new UriBuilder(_requestUrl);
            uriBuilder.Query = queryString.ToString();

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uriBuilder.Uri);
            var responseContentObject = await response.Content.ReadFromJsonAsync<GetTrainsDirectionsResponse>();
            return responseContentObject;
        }
    }
}
