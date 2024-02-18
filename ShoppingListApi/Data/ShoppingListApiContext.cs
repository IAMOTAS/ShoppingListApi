using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Models;

namespace ShoppingListApi.Data
{
    public class ShoppingListApiContext : DbContext
    {
        public ShoppingListApiContext (DbContextOptions<ShoppingListApiContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingListApi.Models.Grocery> Grocery { get; set; } = default!;
    }
}
