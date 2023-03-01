using BurgerSystem.Ability.Docking.CommentApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Ability.Services;

namespace BurgerSystem.Ability.Docking.CommentApp
{
    public interface ICommentService : IAbilityServicer
    {
        Task<bool> AddCommentAsync(CommentCreateDto commentCreateDto);
        Task<List<CommentShowDto>> GetCommentsAsync(int storeId);
    }
}
