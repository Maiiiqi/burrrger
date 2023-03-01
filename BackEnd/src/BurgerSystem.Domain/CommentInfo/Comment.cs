using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Domain.Models;

namespace BurgerSystem.Domain.CommentInfo
{
    public class Comment: BaseModel<int>
    {
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public int TasteScore { get; set; }
        public int TextureScore { get; set; }
        public int VisualScore { get; set; }
        public DateTime CommentDate { get; set; }

        // create comment
        public void CreateComment()
        {
            this.CommentDate = DateTime.Now;
        }
    }
}
