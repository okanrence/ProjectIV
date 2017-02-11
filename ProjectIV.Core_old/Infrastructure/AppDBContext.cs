namespace ProjectIV.Core
{
    using Domain;    //using Domain;
    using System.Data.Entity;
    public partial class AppDBContext : DbContext
    {
        public AppDBContext()
            : base("name=AppDBContext")
        {
        }


        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<CaseMapping> CaseMapping { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<CaseStatus> CaseStatus { get; set; }
        public virtual DbSet<CaseType> CaseType { get; set; }
        public virtual DbSet<ClientContact> ClientContact { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(18, 2));

          }
    }
}
