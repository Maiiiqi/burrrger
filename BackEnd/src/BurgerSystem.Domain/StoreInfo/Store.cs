using BurgerSystem.Domain.CommentInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youshow.Ace.Domain.Models;
using static System.Formats.Asn1.AsnWriter;

namespace BurgerSystem.Domain.StoreInfo
{
    public class Store: BaseModel<int>   // this base class set to object
    {
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string OpeningTime { get; set; }
        public string MenusInfo { get; set; }
        public int CommentCount { get; set; }
        public float TasteScoreAverage { get; set; }
        public float TextureScoreAverage { get; set; }
        public float VisualScoreAverage { get; set; }

        // update scores
        public void UpdateScore(int newTaste, int newTexture, int newVisual)
        {
            TasteScoreAverage = (TasteScoreAverage * CommentCount + newTaste * 1) / (CommentCount + 1);
            TextureScoreAverage = (TextureScoreAverage * CommentCount + newTexture * 1) / (CommentCount + 1);
            VisualScoreAverage = (VisualScoreAverage * CommentCount + newVisual * 1) / (CommentCount + 1);
            CommentCount += 1;
        }
    }
}
