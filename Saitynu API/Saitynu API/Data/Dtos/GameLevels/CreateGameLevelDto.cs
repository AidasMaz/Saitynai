using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Dtos.GameLevels
{
    public record CreateGameLevelDto([Required] string LevelType, [Required] int LevelNumber, 
        [Required] float TimeForTwoCrowns, [Required] float TimeForThreeCrowns, [Required] float PerfectTime);
}