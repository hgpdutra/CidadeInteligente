using CidadeInteligente.Dominio;
using Microsoft.EntityFrameworkCore;

namespace CidadeInteligente.Infraestrutura.Config
{
    public class CidadeInteligenteDbContext : DbContext
    {
        public DbSet<EstacaoRecarga> EstacaoRecargas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetConnectionString());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetConnectionString()
        {
            //Alterar para configurações desejadas:
            return "Server=(localdb)\\MSSQLLocalDB;Database=CidadeInteligente;Trusted_Connection=True;MultipleActiveResultSets=True;";
        }

        public CidadeInteligenteDbContext()
        {

        }

        public CidadeInteligenteDbContext(DbContextOptions<CidadeInteligenteDbContext> options) : base(options)
        {

        }


    }
}
