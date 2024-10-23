using Microsoft.AspNetCore.SignalR;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.SignalRHub
{
    public class SignalRHub : Hub
    {
        private readonly ICommentStatisticService _commentStatisticService;
        //private readonly IMessageStatisticService _messageStatisticService;

        public SignalRHub(ICommentStatisticService commentStatisticService
            )
        {
            _commentStatisticService = commentStatisticService;
            //_messageStatisticService = messageStatisticService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _commentStatisticService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

            //var getTotalMessageCount = _messageStatisticService.GetTotalMessageCountByReceiverId(id);
            //await Clients.All.SendAsync("ReceiveTotalMessageCount", getTotalMessageCount);
        }

    }

}
