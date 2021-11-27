using Microsoft.EntityFrameworkCore;
using Saitynu_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Repositories
{
    public interface IGameLevelsRepository
    {
        Task/*<GameLevel>*/ Create(GameLevel gameLevel);

        Task<IEnumerable<GameLevel>> GetAll();

        Task<GameLevel> Get(int id);

        Task/*<GameLevel>*/ Put(GameLevel gameLevel);

        Task Delete(GameLevel gameLevel);
    }

    public class GameLevelsRepository : IGameLevelsRepository
    {
        private readonly RestContext _restContext;

        public GameLevelsRepository(RestContext restContext)
        {
            _restContext = restContext;
        }

        public async Task<IEnumerable<GameLevel>> GetAll()
        {
            return await _restContext.GameLevels.Where(o => o.Id != 0).ToListAsync();

            //return new List<GameLevel>
            //{
            //    new GameLevel()
            //    {
            //        LevelType = "Pawn",
            //        LevelNumber = 1,
            //        TimeForTwoCrowns = 25.8f,
            //        TimeForThreeCrowns = 22f,
            //        PerfectTime = 20.25f
            //    },
            //    new GameLevel()
            //    {
            //        LevelType = "Rook",
            //        LevelNumber = 3,
            //        TimeForTwoCrowns = 16f,
            //        TimeForThreeCrowns = 14.2f,
            //        PerfectTime = 13.3f
            //    },
            //    new GameLevel()
            //    {
            //        LevelType = "Rook",
            //        LevelNumber = 4,
            //        TimeForTwoCrowns = 31f,
            //        TimeForThreeCrowns = 26.5f,
            //        PerfectTime = 24.12f
            //    }
            //};
        }

        public async Task<GameLevel> Get(int id)
        {
            return await _restContext.GameLevels.FirstOrDefaultAsync(o => o.Id == id);

            //return new GameLevel()
            //{
            //    LevelType = "Rook",
            //    LevelNumber = 4,
            //    TimeForTwoCrowns = 31f,
            //    TimeForThreeCrowns = 26.5f,
            //    PerfectTime = 24.12f
            //};
        }

        public async Task/*<GameLevel>*/ Create(GameLevel gameLevel)
        {
            _restContext.GameLevels.Add(gameLevel);
            await _restContext.SaveChangesAsync();

            //return new GameLevel()
            //{
            //    LevelType = "Rook",
            //    LevelNumber = 4,
            //    TimeForTwoCrowns = 31f,
            //    TimeForThreeCrowns = 26.5f,
            //    PerfectTime = 24.12f
            //};
        }

        public async Task/*<GameLevel> */Put(GameLevel gameLevel)
        {
            _restContext.GameLevels.Update(gameLevel);
            await _restContext.SaveChangesAsync();

            //return new GameLevel()
            //{
            //    LevelType = "Rook",
            //    LevelNumber = 4,
            //    TimeForTwoCrowns = 31f,
            //    TimeForThreeCrowns = 26.5f,
            //    PerfectTime = 24.12f
            //};
        }

        public async Task Delete(GameLevel gameLevel)
        {
            _restContext.GameLevels.Remove(gameLevel);
            await _restContext.SaveChangesAsync();
        }
    }
}