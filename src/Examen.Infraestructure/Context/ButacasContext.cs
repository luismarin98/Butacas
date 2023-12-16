using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public partial class ButacasContext : DbContext
{
    public ButacasContext()
    {
    }

    public ButacasContext(DbContextOptions<ButacasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaseEntity> BaseEntities { get; set; }

    public virtual DbSet<BillboardEntity> BillboardEntities { get; set; }

    public virtual DbSet<BookingEntity> BookingEntities { get; set; }

    public virtual DbSet<CustomerEntity> CustomerEntities { get; set; }

    public virtual DbSet<MovieEntity> MovieEntities { get; set; }

    public virtual DbSet<RoomEntity> RoomEntities { get; set; }

    public virtual DbSet<SeatEntity> SeatEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseEntity>(entity =>
        {
            entity.HasKey(e => e.IdBase).HasName("PK__BaseEnti__DF51D5BE8860937A");

            entity.ToTable("BaseEntity");

            entity.Property(e => e.IdBase)
                .ValueGeneratedNever()
                .HasColumnName("id_base");
        });

        modelBuilder.Entity<BillboardEntity>(entity =>
        {
            entity.HasKey(e => e.IdBillboard).HasName("PK__Billboar__838D0748C3F7A1DE");

            entity.ToTable("BillboardEntity ");

            entity.Property(e => e.IdBillboard)
                .ValueGeneratedNever()
                .HasColumnName("id_billboard");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.IdMovie).HasColumnName("id_movie");
            entity.Property(e => e.IdRoom).HasColumnName("id_room");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.IdMovieNavigation).WithMany(p => p.BillboardEntities)
                .HasForeignKey(d => d.IdMovie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Billboard__id_mo__4222D4EF");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.BillboardEntities)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Billboard__id_ro__4316F928");
        });

        modelBuilder.Entity<BookingEntity>(entity =>
        {
            entity.HasKey(e => e.IdBookin).HasName("PK__BookingE__92DDFB739915F999");

            entity.ToTable("BookingEntity");

            entity.Property(e => e.IdBookin)
                .ValueGeneratedNever()
                .HasColumnName("id_bookin");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IdBillboard).HasColumnName("id_billboard");
            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.IdSeat).HasColumnName("id_seat");

            entity.HasOne(d => d.IdBillboardNavigation).WithMany(p => p.BookingEntities)
                .HasForeignKey(d => d.IdBillboard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingEn__id_bi__47DBAE45");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.BookingEntities)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingEn__id_cu__45F365D3");

            entity.HasOne(d => d.IdSeatNavigation).WithMany(p => p.BookingEntities)
                .HasForeignKey(d => d.IdSeat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingEn__id_se__46E78A0C");
        });

        modelBuilder.Entity<CustomerEntity>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__Customer__8CC9BA46ADA86079");

            entity.ToTable("CustomerEntity");

            entity.Property(e => e.IdCustomer)
                .ValueGeneratedNever()
                .HasColumnName("id_customer");
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Latname)
                .HasMaxLength(30)
                .HasColumnName("latname");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MovieEntity>(entity =>
        {
            entity.HasKey(e => e.IdMovie).HasName("PK__MovieEnt__FB90FCD7779FC2FF");

            entity.ToTable("MovieEntity");

            entity.Property(e => e.IdMovie)
                .ValueGeneratedNever()
                .HasColumnName("id_movie");
            entity.Property(e => e.MovieGenreEnum).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<RoomEntity>(entity =>
        {
            entity.HasKey(e => e.IdRoom).HasName("PK__RoomEnti__3D4978918D97081B");

            entity.ToTable("RoomEntity");

            entity.Property(e => e.IdRoom)
                .ValueGeneratedNever()
                .HasColumnName("id_room");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<SeatEntity>(entity =>
        {
            entity.HasKey(e => e.IdSeat).HasName("PK__SeatEnti__D693BBD451877417");

            entity.ToTable("SeatEntity");

            entity.Property(e => e.IdSeat)
                .ValueGeneratedNever()
                .HasColumnName("id_seat");
            entity.Property(e => e.IdRoom).HasColumnName("id_room");
            entity.Property(e => e.Number).HasMaxLength(30);

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.SeatEntities)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SeatEntit__id_ro__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
