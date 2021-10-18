using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NETDemo.Data.Models.DatabaseModels
{
    public partial class TechnicalAssignmentContext : DbContext
    {
        public TechnicalAssignmentContext()
        {
        }

        public TechnicalAssignmentContext(DbContextOptions<TechnicalAssignmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=TechnicalAssignment; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.customer_id);

                entity.ToTable("Customer");

                entity.Property(e => e.contact_no)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.country_code)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.created_at).HasColumnType("datetime");

                entity.Property(e => e.email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.first_name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.last_name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.updated_at).HasColumnType("datetime");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.employee_id)
                    .HasName("PK__Employee__C52E0BA89DB23EF9");

                entity.ToTable("Employee");

                entity.Property(e => e.first_name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.last_name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.salary).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.log_id);

                entity.ToTable("Log");

                entity.Property(e => e.event_type)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasKey(e => e.user_id)
                    .HasName("PK__SystemUs__B9BE370FAE11902F");

                entity.ToTable("SystemUser");

                entity.Property(e => e.password).HasMaxLength(100);

                entity.Property(e => e.username).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
