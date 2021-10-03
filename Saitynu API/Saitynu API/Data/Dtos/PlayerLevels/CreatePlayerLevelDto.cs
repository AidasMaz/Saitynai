using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Dtos.PlayerLevels
{
    public record CreatePlayerLevelDto([Required] string LevelType, [Required] int LevelNumber, [Required] float CompletionTime, 
        [Required] int NumberOfTries, [Required] int NumberOfSteps, [Required] DateTime CompletionDate);
}
