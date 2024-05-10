using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlackJackk.Models;

namespace BlackJack.Data
{
    public class BlackJackContext : DbContext
    {
        public BlackJackContext (DbContextOptions<BlackJackContext> options)
            : base(options)
        {
        }

        public DbSet<BlackJackk.Models.User> User { get; set; } = default!;
    }
}
