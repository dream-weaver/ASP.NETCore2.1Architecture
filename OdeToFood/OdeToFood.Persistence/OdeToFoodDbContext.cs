using Microsoft.EntityFrameworkCore;
using OdeToFood.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Persistence
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext>options)
            :base(options)
        {
                    
        }
        public DbSet<Restaurant> restaurants { get; set; }
    }
}
