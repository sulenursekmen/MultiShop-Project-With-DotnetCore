
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetActiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("usercomments/GetActiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<long> GetPassiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("usercomments/GetPassiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<long> GetTotalCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("usercomments/GetTotalCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }
    }
}