using Saitynu_API.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Entities
{
    public class PlayerLevel
    {
        public int Id { get; set; }
        public string LevelType { get; set; }
        public int LevelNumber { get; set; }
        public float CompletionTime { get; set; }
        public int NumberOfTries { get; set; }
        public int NumberOfSteps { get; set; }
        public DateTime CompletionDate { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
