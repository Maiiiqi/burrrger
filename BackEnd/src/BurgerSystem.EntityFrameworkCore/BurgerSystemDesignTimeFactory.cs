using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youshow.Ace.EntityFrameworkCore;
using Youshow.Ace.EntityFrameworkCore.MySql;

namespace BurgerSystem.EntityFrameworkCore
{
    public class BurgerSystemDesignTimeFactory : AceMySqlDesignTimeDbContextFactory<BurgerSystemDbContext>
{
    public override AceDesignTimeDbContextOptions Options => new()
    {
        StartupProjectPath = @"../BurgerSystem.Web" //appsetting.json所在目录
    };
}
}
