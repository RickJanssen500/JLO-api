using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Data
{
    public class ConfigureSQL
    {

       static public DbContextOptions<OrderDALContext> Options = new DbContextOptionsBuilder<OrderDALContext>()
                .UseSqlServer("Server=mssqlstud.fhict.local;Database=dbi454010;User Id=dbi454010;Password=70Cent; ")
                .Options;
    }
}
