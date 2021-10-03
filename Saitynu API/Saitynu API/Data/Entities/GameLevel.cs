using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Entities
{
    public class GameLevel
    {
        public int Id { get; set; }
        public string LevelType { get; set; }
        public int LevelNumber { get; set; }
        public float TimeForTwoCrowns { get; set; }
        public float TimeForThreeCrowns { get; set; }
        public float PerfectTime { get; set; }
    }
}
