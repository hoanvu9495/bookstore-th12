namespace BookStore.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContent : DbContext
    {
        public DBContent()
            : base("name=DBContent")
        {
        }

        public virtual DbSet<BSCTDH> BSCTDHs { get; set; }
        public virtual DbSet<BSCTKM> BSCTKMs { get; set; }
        public virtual DbSet<BSDONHANG> BSDONHANGs { get; set; }
        public virtual DbSet<BSKHUYENMAI> BSKHUYENMAIs { get; set; }
        public virtual DbSet<BSLOAI> BSLOAIs { get; set; }
        public virtual DbSet<BSNXB> BSNXBs { get; set; }
        public virtual DbSet<BSSACH> BSSACHes { get; set; }
        public virtual DbSet<BSTACGIA> BSTACGIAs { get; set; }
        public virtual DbSet<BSTACGIASACH> BSTACGIASACHes { get; set; }
        public virtual DbSet<BSUSER> BSUSERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BSDONHANG>()
                .HasMany(e => e.BSCTDHs)
                .WithRequired(e => e.BSDONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BSKHUYENMAI>()
                .HasMany(e => e.BSCTKMs)
                .WithRequired(e => e.BSKHUYENMAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BSNXB>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<BSSACH>()
                .HasMany(e => e.BSCTDHs)
                .WithRequired(e => e.BSSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BSSACH>()
                .HasMany(e => e.BSCTKMs)
                .WithRequired(e => e.BSSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BSSACH>()
                .HasMany(e => e.BSTACGIASACHes)
                .WithRequired(e => e.BSSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BSTACGIA>()
                .Property(e => e.AVATAR)
                .IsUnicode(false);

            modelBuilder.Entity<BSTACGIA>()
                .HasMany(e => e.BSTACGIASACHes)
                .WithRequired(e => e.BSTACGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BSUSER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<BSUSER>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<BSUSER>()
                .Property(e => e.TAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<BSUSER>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<BSUSER>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<BSUSER>()
                .HasMany(e => e.BSDONHANGs)
                .WithOptional(e => e.BSUSER)
                .HasForeignKey(e => e.MAKHACHHANG);
        }
    }
}
