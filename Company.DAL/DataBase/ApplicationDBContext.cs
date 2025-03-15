namespace Company.DAL.DataBase
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-A0LMSG6\\SD;Database=CompanyDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true ");
        }
       public DbSet<Employee> Employees { get; set; }
    }
}
