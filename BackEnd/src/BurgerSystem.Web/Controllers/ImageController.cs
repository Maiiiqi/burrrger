using BurgerSystem.Ability.Docking.ImageApp;
using BurgerSystem.Ability.Docking.ImageApp.Dto;
using BurgerSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerSystem.Web.Controllers
{
    public class ImageController : BaseController
    {
        // DI
        public IImageService ImageService { get; set; }

        //APIs
        // upload image
        [HttpPost("Upload{token}")]
        public async Task<string> UploadImageAsync([FromForm] ImageDto uploadImg, string token)
        {
            //try
            //{
            //    if (uploadImg.File.Length > 0)
            //    {
            //        // var path = WebHostEnvironment.WebRootPath + "\\uploads\\";
            //        var path = WebHostEnvironment.ContentRootPath + "\\uploads\\";
            //        if (!Directory.Exists(path))
            //        {
            //            Directory.CreateDirectory(path);
            //        }
            //        using (FileStream stream = System.IO.File.Create(path + uploadImg.File.FileName))
            //        {
            //            uploadImg.File.CopyTo(stream);
            //            stream.Flush();
            //            return "Success!";
            //        }
            //    }
            //    else
            //        return "Failed!";
            //}
            //catch (Exception ex)
            //{

            //    return ex.Message;
            //}
            if (LoginSuccessInfo != null)
            {
                var userId = LoginSuccessInfo.Id;
                return await ImageService.UploadImageAsync(uploadImg, userId);
            }
            else
                return "Please login first!";
            
        }

        // get image
        [HttpGet]
        public async Task<IActionResult> GetImageAsync(string filename)
        {
            //var path = WebHostEnvironment.ContentRootPath + "\\uploads\\";
            //var filePath = path + fileName + ".png";
            //if (System.IO.File.Exists(filePath))
            //{
            //    byte[] b = System.IO.File.ReadAllBytes(filePath);
            //    return File(b, "image/png");
            //}
            //return null;
            var path = await ImageService.GetImageAsync(filename);
            if(path != null)
            {
                byte[] b = System.IO.File.ReadAllBytes(path);
                return File(b, "image/png");
            }
            return NoContent();
        }

        //[HttpGet("All")]
        //public async Task<List<IActionResult>> GetAll(int id)
        //{
        //    List<string> paths = await ImageService.GetImages(id);
        //    if(paths != null)
        //    {
        //        List<object> res = new List<object>();
        //        foreach (string path in paths)
        //        {
        //            if (path != null)
        //            {
        //                byte[] b = System.IO.File.ReadAllBytes(path);
        //                res.Add(File(b, "image/png"));
        //            }
        //        }
        //        return null;
        //    }    
        //    return null;
        //}
    }
}
