using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
