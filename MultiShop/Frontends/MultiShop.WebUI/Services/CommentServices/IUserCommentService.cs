using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface IUserCommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task<List<ResultCommentDto>> CommentListByProductId(string id);
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string id);
        Task<GetByIdCommentDto> GetByIdCommentAsync(string id);
        Task<UpdateCommentDto> GetByIdForUpdateCommentAsync(string id);
    }
}
