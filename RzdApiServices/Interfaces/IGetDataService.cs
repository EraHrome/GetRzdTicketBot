namespace RzdApi.Services.Interfaces
{
    public interface IGetDataService<TRequest, TResponse>
    {
        public Task<TResponse> GetData(TRequest request);
    }
}
