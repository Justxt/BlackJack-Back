using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackJack.Data;
using BlackJackk.Models;

namespace BlackJack.Controllers
{
    public class UsersController : Controller
    {
        private readonly BlackJackContext _context;

        public UsersController(BlackJackContext context)
        {
            _context = context;
        }

       
    }
}
