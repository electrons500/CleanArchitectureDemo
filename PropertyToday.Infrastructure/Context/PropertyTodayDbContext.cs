using Microsoft.EntityFrameworkCore;
using PropertyToday.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyToday.Infrastructure.Context
{
    public class PropertyTodayDbContext : DbContext
    {
        public PropertyTodayDbContext(DbContextOptions<PropertyTodayDbContext> options) : base(options)
        {
            
        }

        public DbSet<Property> Properties => Set<Property>();
        public DbSet<Image> Images => Set<Image>();


    }
}
