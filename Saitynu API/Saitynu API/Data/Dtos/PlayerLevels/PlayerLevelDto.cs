using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Dtos.PlayerLevels
{
    public record PlayerLevelDto(int Id, string LevelType, int LevelNumber, float CompletionTime, int NumberOfTries, int NumberOfSteps, DateTime CompletionDate);
}
