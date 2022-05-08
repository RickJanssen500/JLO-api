using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBLL.Data
{
    class ConfigureSQL
    {

       static public DbContextOptions<OrderBLLContext> Options = new DbContextOptionsBuilder<OrderBLLContext>()
                .UseSqlServer("Server=mssqlstud.fhict.local;Database=dbi454010;User Id=dbi454010;Password=70Cent; ")
                .Options;
    }
}
