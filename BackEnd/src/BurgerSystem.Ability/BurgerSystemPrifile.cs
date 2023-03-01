using AutoMapper;
using BurgerSystem.Ability.Docking.CommentApp.Dto;
using BurgerSystem.Ability.Docking.StoreApp.Dto;
using BurgerSystem.Ability.Docking.UserApp.Dto;
using BurgerSystem.Domain.AccountInfo;
using BurgerSystem.Domain.CommentInfo;
using BurgerSystem.Domain.StoreInfo;

namespace BurgerSystemSystem.Ability
{
    public class BurgerSystemPrifile : Profile
    {
        // for Mapping Rules
        public BurgerSystemPrifile()
        {
            // mapping for check login
            CreateMap<User, LoginSuccessDto>();
            // mapping for register
            CreateMap<UserCreateDto, User>();
            // mapping for store
            CreateMap<Store, StoreDto>();
            // mapping for comment
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<Comment, CommentShowDto>();
        }
    }
}
