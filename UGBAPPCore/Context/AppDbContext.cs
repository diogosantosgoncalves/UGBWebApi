using APPTCCUGB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace APPTCCUGB.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Parada> Paradas { get; set; }
        public DbSet<Perda> Perdas { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producao> Producoes { get; set; }

        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfiguration configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", false, true)
            //    .Build();

            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
            optionsBuilder.UseSqlServer("Password=senha;Persist Security Info=True;User ID=sa;Initial Catalog=TccUGB;Data Source=DESKTOP-K6KF994\\SQL2014");
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContext>
               (options => options.UseSqlServer("Password=senha;Persist Security Info=True;User ID=sa;Initial Catalog=TccUGB;Data Source=DESKTOP-K6KF994\\SQL2014"));


            services.AddTransient(typeof(UserControlCadastroProdutos));
        }
    }
}
