using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Youshow.Ace.Data;
using Youshow.Ace.EntityFrameworkCore;

namespace BurgerSystem.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class BurgerSystemDbContext : AceDbContext<BurgerSystemDbContext>
    {
        public BurgerSystemDbContext(DbContextOptions<BurgerSystemDbContext> options) : base(options)
        {
        }
    }
}
