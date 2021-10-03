using Saitynu_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Repositories
{
    public interface IPlayersRepository
    {
        Task<Player> Create(Player player);

        Task<IEnumerable<Player>> GetAll();

        Task<Player> Get(int id);

        Task<Player> Put(Player player);

        Task Delete(Player player);
    }

    public class PlayersRepository : IPlayersRepository
    {
        public async Task<IEnumerable<Player>> GetAll()
        {
            return new List<Player>
            {
                new Player()
                {
                    Nick = "BestPlayer",
                    Type = "Regular",
                    CreationDate = DateTime.UtcNow
                },
                new Player()
                {
                    Nick = "Testuotojas",
                    Type = "Tester",
                    CreationDate = DateTime.UtcNow
                }
            };
        }

        public async Task<Player> Get(int id)
        {
            return new Player()
            {
                Nick = "BestPlayer",
                Type = "Regular",
                CreationDate = DateTime.UtcNow
            };
        }

        public async Task<Player> Create(Player player)
        {
            return new Player()
            {
                Nick = "BestPlayer",
                Type = "Regular",
                CreationDate = DateTime.UtcNow
            };
        }

        public async Task<Player> Put(Player player)
        {
            return new Player()
            {
                Nick = "BestPlayer",
                Type = "Regular",
                CreationDate = DateTime.UtcNow
            };
        }

        public async Task Delete(Player player)
        {
        }
    }
}
