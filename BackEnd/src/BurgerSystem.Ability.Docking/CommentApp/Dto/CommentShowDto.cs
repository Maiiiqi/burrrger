using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerSystem.Ability.Docking.CommentApp.Dto
{
    public class CommentShowDto
    {
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public string TasteScore { get; set; }
        public string TextureScore { get; set; }
        public string VisualScore { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
