using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerSystem.Ability.Docking.CommentApp.Dto
{
    // comment object received from front end
    public class CommentCreateDto
    {
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public int TasteScore { get; set; }
        public int TextureScore { get; set; }
        public int VisualScore { get; set; }
    }
}
