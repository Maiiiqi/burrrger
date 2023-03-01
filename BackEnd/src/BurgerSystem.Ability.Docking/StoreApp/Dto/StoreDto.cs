using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Ability.Dtos;

namespace BurgerSystem.Ability.Docking.StoreApp.Dto
{
    public class StoreDto: BaseModelDto<int>
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string MenusInfo { get; set; }
        public float TasteScoreAverage { get; set; }
        public float TextureScoreAverage { get; set; }
        public float VisualScoreAverage { get; set; }
    }
}
