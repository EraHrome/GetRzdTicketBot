using RzdApi.Services.Implementations.GetTrainsPlacesDataService.Models;
using RzdApi.Services.Interfaces;
using System.Net.Http.Json;

namespace RzdApi.Services.Implementations.GetTrainsPlacesDataService
{
    /// <summary>
    /// Сервис для получения данных о местах в конкретном рейсе конкретного поезда.
    /// </summary>
    public class GetTrainsPlacesDataService : IGetDataService<GetTrainsPlacesDataRequest, IEnumerable<TrainPlacesData>>
    {
        private static string _requestUrl = "https://ticket.rzd.ru/api/v1/railway/carpricing/lite";

        public async Task<IEnumerable<TrainPlacesData>> GetData(GetTrainsPlacesDataRequest request)
        {
            HttpClient httpClient = new HttpClient();
            var content = JsonContent.Create(request);
            var response = await httpClient.PostAsync(_requestUrl, content);
            var responseContentObject = await response.Content.ReadFromJsonAsync<TrainPlacesData[]>();
            return responseContentObject;
        }
    }
}
