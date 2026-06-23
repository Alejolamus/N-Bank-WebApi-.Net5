using Microsoft.EntityFrameworkCore;
using NBankApi.Models.DataBase;

namespace NBankApi.Models.DbContext
{
    public class DbContextNBank : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContextNBank(DbContextOptions<DbContextNBank> options)
            : base(options)
        {

        }

        public DbSet<Clients> Clientes { get; set; }
        public DbSet<Collects> Recaudos { get; set; }
        public DbSet<Credits> Creditos { get; set; }
        public DbSet<Currencys> Divisas { get; set; }
        public DbSet<FinancialProfiles> PerfilesMonetarios { get; set; }
        public DbSet<Invoices> Facturas { get; set; }
        public DbSet<Partners> Aliados { get; set; }
        public DbSet<MunicipalityCol> Municipios { get; set; }
        public DbSet<FinancialStatus> EstadosFinancieros { get; set; }
        
    }

}
