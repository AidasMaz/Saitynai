using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Saitynu_API.Data.Dtos.Auth;
using Saitynu_API.Data.Entities;

namespace Saitynu_API.Data
{
    public class RestContext : IdentityDbContext<RestUser>
    {
        public DbSet<GameLevel> GameLevels { get; set; }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerLevel> PlayerLevels { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=SaitynuDb6");
        }
    }
}
