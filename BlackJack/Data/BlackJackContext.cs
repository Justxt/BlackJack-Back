using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlackJack.Models;

namespace BlackJack.Data
{
    public class BlackJackContext : DbContext
    {
        public BlackJackContext (DbContextOptions<BlackJackContext> options)
            : base(options)
        {
        }

        public DbSet<BlackJack.Models.User> User { get; set; } = default!;
        public DbSet<BlackJack.Models.PaymentMethod> PaymentMethod { get; set; } = default!;
        public DbSet<BlackJack.Models.CreditCard> CreditCard { get; set; } = default!;
        public DbSet<BlackJack.Models.SupportTicket> SupportTicket { get; set; } = default!;
    }
}
