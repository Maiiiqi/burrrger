using BurgerSystem.Ability.Docking.CommentApp;
using BurgerSystem.Ability.Docking.CommentApp.Dto;
using BurgerSystem.Domain.CommentInfo;
using BurgerSystem.Domain.StoreInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Ability;
using Youshow.Ace.Domain.Repository;

namespace BurgerSystem.Ability.CommentApp
{
    // bll layer
    // conversion between domain and object
    public class CommentService: AbilityServicer, ICommentService
    {
        // dependency injection
        public IRepository<Comment> CommentRepo { get; set; }
        public IRepository<Store> StoreRepo { get; set; }

        // insert comment to repo
        public async Task<bool> AddCommentAsync(CommentCreateDto commentCreateDto)
        {
            try
            {
                // dto conversion
                var comment = ModelMapper.Map<CommentCreateDto, Comment>(commentCreateDto);
                // add other properties
                comment.CreateComment();
                // insert to repo
                await CommentRepo.InsertAsync(comment);
                // refresh score of store
                if(comment.StoreId != 0 && comment.TasteScore != 0 && comment.TextureScore != 0 && comment.VisualScore != 0)
                {
                    var store = await StoreRepo.GetAsync(m => m.Id == comment.StoreId);
                    store.UpdateScore(comment.TasteScore, comment.TextureScore, comment.VisualScore);
                    await StoreRepo.UpdateAsync(store);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        // get comment from repo
        public async Task<List<CommentShowDto>> GetCommentsAsync(int storeId)
        {
            var commentList = await CommentRepo.Where(m => m.StoreId == storeId).OrderByDescending(m => m.CommentDate).ToListAsync();
            var commentShowDtos = ModelMapper.Map<List<Comment>, List<CommentShowDto>>(commentList);
            return commentShowDtos;
        }
    }
}
