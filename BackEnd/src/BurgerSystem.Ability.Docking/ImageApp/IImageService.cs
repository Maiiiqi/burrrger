using BurgerSystem.Ability.Docking.ImageApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Ability.Services;

namespace BurgerSystem.Ability.Docking.ImageApp
{
    public interface IImageService: IAbilityServicer
    {
        Task<string> UploadImageAsync(ImageDto image, int id);
        Task<string?> GetImageAsync(string filename);
        //Task<List<string?>> GetImages(int userId);
    }
}
