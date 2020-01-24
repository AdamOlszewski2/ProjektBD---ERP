using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RazorBD.Models
{
    public partial class ProjektBDContext : DbContext
    {
        public ProjektBDContext()
        {
        }

        public ProjektBDContext(DbContextOptions<ProjektBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllDocuments> AllDocuments { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<Departament> Departament { get; set; }
        public virtual DbSet<Invoicedocument> Invoicedocument { get; set; }
        public virtual DbSet<Invoicedocumentposition> Invoicedocumentposition { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Saledocument> Saledocument { get; set; }
        public virtual DbSet<Saledocumentposition> Saledocumentposition { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vatrate> Vatrate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LEGION\\SQL2017DEV;Database=ProjektBD;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllDocuments>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ALL_DOCUMENTS");

                entity.Property(e => e.Contractorid).HasColumnName("CONTRACTORID");

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Documentid).HasColumnName("DOCUMENTID");

                entity.Property(e => e.Documentnumber)
                    .IsRequired()
                    .HasColumnName("DOCUMENTNUMBER")
                    .HasMaxLength(50);

                entity.Property(e => e.Grosssum)
                    .HasColumnName("GROSSSUM")
                    .HasColumnType("money");

                entity.Property(e => e.Invoicedate)
                    .HasColumnName("INVOICEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Moddate)
                    .HasColumnName("MODDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Netsum)
                    .HasColumnName("NETSUM")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("USERID");
            });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("CONTRACTOR");

                entity.HasIndex(e => e.Nip)
                    .HasName("INDX_CONTRACTOR_NIP");

                entity.Property(e => e.Contractorid).HasColumnName("CONTRACTORID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Bankaccount).HasColumnName("BANKACCOUNT");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nip).HasColumnName("NIP");
            });

            modelBuilder.Entity<Departament>(entity =>
            {
                entity.ToTable("DEPARTAMENT");

                entity.Property(e => e.Departamentid).HasColumnName("DEPARTAMENTID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Short)
                    .IsRequired()
                    .HasColumnName("SHORT")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoicedocument>(entity =>
            {
                entity.HasKey(e => e.Documentid);

                entity.ToTable("INVOICEDOCUMENT");

                entity.Property(e => e.Documentid).HasColumnName("DOCUMENTID");

                entity.Property(e => e.Contractorid).HasColumnName("CONTRACTORID");

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Documentnumber)
                    .IsRequired()
                    .HasColumnName("DOCUMENTNUMBER")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(NEXT VALUE FOR [INVOICEDOCNUBMERSEQ])");

                entity.Property(e => e.Grosssum)
                    .HasColumnName("GROSSSUM")
                    .HasColumnType("money");

                entity.Property(e => e.Invoicedate)
                    .HasColumnName("INVOICEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Moddate)
                    .HasColumnName("MODDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Netsum)
                    .HasColumnName("NETSUM")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.Invoicedocument)
                    .HasForeignKey(d => d.Contractorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVOICEDO__CONTR__73BA3083");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invoicedocument)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVOICEDO__USERI__72C60C4A");
            });

            modelBuilder.Entity<Invoicedocumentposition>(entity =>
            {
                entity.ToTable("INVOICEDOCUMENTPOSITION");

                entity.Property(e => e.Invoicedocumentpositionid).HasColumnName("INVOICEDOCUMENTPOSITIONID");

                entity.Property(e => e.Documentid).HasColumnName("DOCUMENTID");

                entity.Property(e => e.Grosssum)
                    .HasColumnName("GROSSSUM")
                    .HasColumnType("money");

                entity.Property(e => e.Netsum)
                    .HasColumnName("NETSUM")
                    .HasColumnType("money");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Unitprice)
                    .HasColumnName("UNITPRICE")
                    .HasColumnType("money");

                entity.Property(e => e.Vatrateid).HasColumnName("VATRATEID");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Invoicedocumentposition)
                    .HasForeignKey(d => d.Documentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVOICEDO__DOCUM__02FC7413");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Invoicedocumentposition)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVOICEDO__PRODU__03F0984C");

                entity.HasOne(d => d.Vatrate)
                    .WithMany(p => p.Invoicedocumentposition)
                    .HasForeignKey(d => d.Vatrateid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVOICEDO__VATRA__04E4BC85");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Netprice)
                    .HasColumnName("NETPRICE")
                    .HasColumnType("money");

                entity.Property(e => e.Plu).HasColumnName("PLU");

                entity.Property(e => e.Stock).HasColumnName("STOCK");

                entity.Property(e => e.Vatrateid).HasColumnName("VATRATEID");

                entity.HasOne(d => d.Vatrate)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Vatrateid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUCT__VATRATE__440B1D61");
            });

            modelBuilder.Entity<Saledocument>(entity =>
            {
                entity.HasKey(e => e.Documentid);

                entity.ToTable("SALEDOCUMENT");

                entity.Property(e => e.Documentid).HasColumnName("DOCUMENTID");

                entity.Property(e => e.Contractorid).HasColumnName("CONTRACTORID");

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Documentnumber)
                    .IsRequired()
                    .HasColumnName("DOCUMENTNUMBER")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(NEXT VALUE FOR [SALEDOCNUBMERSEQ])");

                entity.Property(e => e.Grosssum)
                    .HasColumnName("GROSSSUM")
                    .HasColumnType("money");

                entity.Property(e => e.Invoicedate)
                    .HasColumnName("INVOICEDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Moddate)
                    .HasColumnName("MODDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Netsum)
                    .HasColumnName("NETSUM")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.Saledocument)
                    .HasForeignKey(d => d.Contractorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SALEDOCUM__CONTR__6C190EBB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Saledocument)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SALEDOCUM__USERI__6B24EA82");
            });

            modelBuilder.Entity<Saledocumentposition>(entity =>
            {
                entity.ToTable("SALEDOCUMENTPOSITION");

                entity.Property(e => e.Saledocumentpositionid).HasColumnName("SALEDOCUMENTPOSITIONID");

                entity.Property(e => e.Documentid).HasColumnName("DOCUMENTID");

                entity.Property(e => e.Grosssum)
                    .HasColumnName("GROSSSUM")
                    .HasColumnType("money");

                entity.Property(e => e.Netsum)
                    .HasColumnName("NETSUM")
                    .HasColumnType("money");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Unitprice)
                    .HasColumnName("UNITPRICE")
                    .HasColumnType("money");

                entity.Property(e => e.Vatrateid).HasColumnName("VATRATEID");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Saledocumentposition)
                    .HasForeignKey(d => d.Documentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SALEDOCUM__DOCUM__778AC167");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Saledocumentposition)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SALEDOCUM__PRODU__787EE5A0");

                entity.HasOne(d => d.Vatrate)
                    .WithMany(p => p.Saledocumentposition)
                    .HasForeignKey(d => d.Vatrateid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SALEDOCUM__VATRA__797309D9");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.ToTable("USERS");

                entity.HasIndex(e => e.Departamentid)
                    .HasName("INDX_USERS_DEPTID");

                entity.HasIndex(e => e.Login)
                    .HasName("UQ_LOGIN")
                    .IsUnique();

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Departamentid).HasColumnName("DEPARTAMENTID");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("LOGIN")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Departament)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Departamentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USERS__DEPARTAME__4D94879B");
            });

            modelBuilder.Entity<Vatrate>(entity =>
            {
                entity.ToTable("VATRATE");

                entity.HasIndex(e => e.Vatrateamount)
                    .HasName("UQ_VATRATEAMOUNT")
                    .IsUnique();

                entity.Property(e => e.Vatrateid)
                    .HasColumnName("VATRATEID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Vatrateamount).HasColumnName("VATRATEAMOUNT");
            });

            modelBuilder.HasSequence<int>("INVOICEDOCNUBMERSEQ").HasMin(1);

            modelBuilder.HasSequence<int>("SALEDOCNUBMERSEQ").HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
