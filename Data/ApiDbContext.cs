using Microsoft.EntityFrameworkCore;
using TODOLOQUEPUEDASCOMER.Models;

namespace TODOLOQUEPUEDASCOMER.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Platillos Mas Pedidos

            modelBuilder.Entity<Menu>().HasData(

                new Menu
                {
                    Id = 1,
                    Platillo = "Salmón a la plancha con arroz y espárragos",
                    Bebidas = "Jugo de naranja",
                    Precio = "5 $"

                },
                new Menu
                {
                    Id = 2,
                    Platillo = "Anguila teriyaki con sésamo",
                    Bebidas = "Chai",
                    Precio = "5 $"

                },

                new Menu
                {
                    Id = 3,
                    Platillo = "Solomillo de cordero al horno con costra verde y chalotas",
                    Bebidas = "Coca Cola ",
                    Precio = "5 $"

                }

                );

            #endregion
        }
        }
    }
