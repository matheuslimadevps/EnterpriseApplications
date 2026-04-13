using EAS.Catalogo.API.Models;
using EAS.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EAS.Catalogo.API.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options)
            : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //boa prática para evitar que algum campo escape do contexto e seja criado como NVARCHAR MAX
            //o map vai auto entender que se o campo é definido como tipo string, ele tem um limite de 100 caracteres por padrão
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
