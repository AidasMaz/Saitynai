using Saitynu_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Repositories
{
    public interface IPlayerLevelsRepository
    {
        Task<IEnumerable<PlayerLevel>> GetAll(int playerID);
        Task<PlayerLevel> Get(int playerId, int playerLevelId);
        Task<PlayerLevel> Create(PlayerLevel playerLevel);
        Task<PlayerLevel> Put(PlayerLevel playerLevel);
        Task Delete(PlayerLevel playerLevel);
    }
    public class PlayerLevelsRepository : IPlayerLevelsRepository
    {
        public async Task<IEnumerable<PlayerLevel>> GetAll(int playerID)
        {
            return new List<PlayerLevel>
            {
                new PlayerLevel()
                {
                    LevelType = "Pawn",
                    LevelNumber = 1,
                    CompletionTime = 21.14f,
                    NumberOfTries = 3,
                    NumberOfSteps = 15,
                    CompletionDate = DateTime.UtcNow
                },
                new PlayerLevel()
                {
                    LevelType = "Pawn",
                    LevelNumber = 2,
                    CompletionTime = 35.27f,
                    NumberOfTries = 5,
                    NumberOfSteps = 23,
                    CompletionDate = DateTime.UtcNow.AddMinutes(5).AddSeconds(12)
                },
                new PlayerLevel()
                {
                    LevelType = "Rook",
                    LevelNumber = 1,
                    CompletionTime = 17.03f,
                    NumberOfTries = 2,
                    NumberOfSteps = 8,
                    CompletionDate = DateTime.UtcNow.AddMinutes(9).AddSeconds(47)
                }
            };
        }

        public async Task<PlayerLevel> Get(int playerId, int playerLevelId)
        {
            return new PlayerLevel()
            {
                LevelType = "Rook",
                LevelNumber = 1,
                CompletionTime = 17.03f,
                NumberOfTries = 2,
                NumberOfSteps = 8,
                CompletionDate = DateTime.UtcNow.AddMinutes(9).AddSeconds(47)
            };
        }

        public async Task<PlayerLevel> Create(PlayerLevel playerLevel)
        {
            return new PlayerLevel()
            {
                LevelType = "Rook",
                LevelNumber = 1,
                CompletionTime = 17.03f,
                NumberOfTries = 2,
                NumberOfSteps = 8,
                CompletionDate = DateTime.UtcNow.AddMinutes(9).AddSeconds(47)
            };
        }

        public async Task<PlayerLevel> Put(PlayerLevel playerLevel)
        {
            return new PlayerLevel()
            {
                LevelType = "Rook",
                LevelNumber = 1,
                CompletionTime = 17.03f,
                NumberOfTries = 2,
                NumberOfSteps = 8,
                CompletionDate = DateTime.UtcNow.AddMinutes(9).AddSeconds(47)
            };
        }

        public async Task Delete(PlayerLevel playerLevel)
        {
        }
    }
}