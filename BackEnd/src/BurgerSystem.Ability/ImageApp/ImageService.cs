using BurgerSystem.Ability.Docking.ImageApp;
using BurgerSystem.Ability.Docking.ImageApp.Dto;
using BurgerSystem.Domain.AccountInfo;
using BurgerSystem.Domain.StoreInfo;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Ability;
using Youshow.Ace.Domain.Repository;

namespace BurgerSystem.Ability.ImageApp
{
    public class ImageService: AbilityServicer, IImageService
    {
        // DI
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        public IRepository<User> UserRepo { get; set; }

        // upload image
        public async Task<string> UploadImageAsync(ImageDto image, int id)
        {
            try
            {
                var user = await UserRepo.GetAsync(m => m.Id == id);              
                if (image.File.Length > 0)
                {
                    var userPath = user.ImagePath;
                    if (userPath == null)
                    {
                        userPath = WebHostEnvironment.ContentRootPath + "\\images\\" + user.Id + "\\";   // unique path
                        user.ImagePath = userPath;
                        UserRepo.UpdateAsync(user);
                    }
                    if (!Directory.Exists(userPath))
                    {
                        Directory.CreateDirectory(userPath);
                    }
                    var path = userPath += image.File.FileName;
                    using (FileStream stream = System.IO.File.Create(path))
                    {
                        image.File.CopyTo(stream);
                        stream.Flush();
                        return "Success!";
                    }

                }
                else
                    return "Failed!";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        // get image
        public async Task<string?> GetImageAsync(string fileName)
        {
            var path = WebHostEnvironment.ContentRootPath + "\\images\\1\\";
            var filePath = path + fileName + ".png";
            if (File.Exists(filePath))
                return filePath;
            else return null;
        }

        //    // get all images
        //    public async Task<List<string?>> GetImages(int userId)
        //    {
        //        var user = await UserRepo.GetAsync(m => m.Id == userId);
        //        var path = user.ImagePath;
        //        List<string> imagesPath = new List<string>();
        //        if(path != null)
        //        {
        //            DirectoryInfo directoryInfo = new DirectoryInfo(path); 
        //            if(directoryInfo.Exists)
        //            {
        //                foreach (FileInfo fileInfo in directoryInfo.GetFiles()) 
        //                { 
        //                    imagesPath.Add(path + fileInfo.Name);
        //                }
        //            }
        //            return imagesPath;
        //        }
        //        return null;
        //    }
    }
}
