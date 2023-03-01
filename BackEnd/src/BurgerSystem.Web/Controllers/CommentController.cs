using BurgerSystem.Ability.Docking.CommentApp;
using BurgerSystem.Ability.Docking.CommentApp.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BurgerSystem.Web.Controllers
{
    public class CommentController: BaseController
    {
        // Dependency Injection
        public ICommentService CommentService { get; set; }

        // APIs

        // add comment
        [HttpPost("AddComment{token}")]
        public async Task<bool> AddCommentAsync(string token, CommentCreateDto commentCreateDto)
        {
            if(LoginSuccessInfo != null)
            {
                commentCreateDto.UserId = LoginSuccessInfo.Id;
                return await CommentService.AddCommentAsync(commentCreateDto);
            }
            return false;
        }

        // get comments
        [HttpGet("ShowComments")]
        public async Task<List<CommentShowDto>> GetCommentsAsync(int storeId)
        {
            return await CommentService.GetCommentsAsync(storeId);
        }
    }
}
