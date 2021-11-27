using Microsoft.EntityFrameworkCore;
using Saitynu_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Repositories
{
    public interface IPlayersRepository
    {
        Task/*<Player>*/ Create(Player player);

        Task<IEnumerable<Player>> GetAll();

        Task<Player> Get(int id);

        Task/*<Player>*/ Put(Player player);

        Task Delete(Player player);
    }

    public class PlayersRepository : IPlayersRepository
    {
        private readonly RestContext _restContext;

        public PlayersRepository(RestContext restContext)
        {
            _restContext = restContext;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await _restContext.Players.Where(o => o.Id != 0).ToListAsync();

            //return new List<Player>
            //{
            //    new Player()
            //    {
            //        Nick = "BestPlayer",
            //        Type = "Regular",
            //        CreationDate = DateTime.UtcNow
            //    },
            //    new Player()
            //    {
            //        Nick = "Testuotojas",
            //        Type = "Tester",
            //        CreationDate = DateTime.UtcNow
            //    }
            //};
        }

        public async Task<Player> Get(int id)
        {
            return await _restContext.Players.FirstOrDefaultAsync(o => o.Id == id);

            //return new Player()
            //{
            //    Nick = "BestPlayer",
            //    Type = "Regular",
            //    CreationDate = DateTime.UtcNow
            //};
        }

        public async Task/*<Player>*/ Create(Player player)
        {
            _restContext.Players.Add(player);
            await _restContext.SaveChangesAsync();

            //return new Player()
            //{
            //    Nick = "BestPlayer",
            //    Type = "Regular",
            //    CreationDate = DateTime.UtcNow
            //};
        }

        public async Task/*<Player>*/ Put(Player player)
        {
            _restContext.Players.Update(player);
            await _restContext.SaveChangesAsync();

            //return new Player()
            //{
            //    Nick = "BestPlayer",
            //    Type = "Regular",
            //    CreationDate = DateTime.UtcNow
            //};
        }

        public async Task Delete(Player player)
        {
            _restContext.Players.Remove(player);
            await _restContext.SaveChangesAsync();
        }
    }
}
