using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Dtos
{
    public record GameLevelDto(int Id, string LevelType, int LevelNumber, float TimeForTwoCrowns, float TimeForThreeCrowns, float PerfectTime);
}