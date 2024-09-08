using RzdApi.Services.Implementations.GetTrainsDataService.Models;
using RzdApi.Services.Interfaces;
using System.Net.Http.Json;

namespace RzdApi.Services.Implementations.GetTrainsDataService
{
    /// <summary>
    /// Сервис для получения данных о поездах по указанному маршруту в определенную дату.
    /// </summary>
    public class GetTrainsDataService : IGetDataService<GetTrainsDataRequest, GetTrainsDataResponse>
    {
        private static string _requestUrl = "https://ticket.rzd.ru/apib2b/p/Railway/V1/Search/TrainPricing?service_provider=B2B_RZD&bs=bf21557f-4847-4c85-90c3-c17bb044996c";

        public async Task<GetTrainsDataResponse> GetData(GetTrainsDataRequest request)
        {
            HttpClient httpClient = new HttpClient();
            var content = JsonContent.Create(request);
            var response = await httpClient.PostAsync(_requestUrl, content);
            var responseContentObject = await response.Content.ReadFromJsonAsync<GetTrainsDataResponse>();
            return responseContentObject;
        }
    }
}
