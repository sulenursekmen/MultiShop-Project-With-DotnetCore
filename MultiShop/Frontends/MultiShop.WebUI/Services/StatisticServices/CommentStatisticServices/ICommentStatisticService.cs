using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public interface ICommentStatisticService
    {
        Task<long> GetTotalCommentCount();
        Task<long> GetPassiveCommentCount();
        Task<long> GetActiveCommentCount();
    }
}
