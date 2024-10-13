using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Institute_of_Fine_Arts.Models;

public partial class DotneteproContext : DbContext
{
    public DotneteproContext()
    {
    }

    public DotneteproContext(DbContextOptions<DotneteproContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Award> Awards { get; set; }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<Exhibition> Exhibitions { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<PaintEx> PaintExes { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Submission> Submissions { get; set; }

    public virtual DbSet<User> Users { get; set; }
    //Home
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("data source=DESKTOP-G0FPI5S\\SQLEXPRESS;initial catalog=dotnetepro;user id=sa;password=aptech; TrustServerCertificate=True");

    //Aptech
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseSqlServer("data source=.;initial catalog=dotnetepro;user id=sa;password=aptech; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3213E83F37921121");

            entity.ToTable("Admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<Award>(entity =>
        {
            entity.HasKey(e => e.AwardId).HasName("PK__Awards__594992A90A2CAD46");

            entity.Property(e => e.AwardId).HasColumnName("award_id");
            entity.Property(e => e.AwardDescription)
                .HasColumnType("text")
                .HasColumnName("award_description");
            entity.Property(e => e.AwardName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("award_name");
            entity.Property(e => e.CompetitionId).HasColumnName("competition_id");
            entity.Property(e => e.DateAwarded)
                .HasColumnType("date")
                .HasColumnName("date_awarded");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Competition).WithMany(p => p.Awards)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Awards__competit__3A81B327");

            entity.HasOne(d => d.Student).WithMany(p => p.Awards)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Awards__student___398D8EEE");
        });

        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.CompetId).HasName("PK__Competit__A21B52660D8A4853");

            entity.Property(e => e.CompetId).HasColumnName("compet_id");
            entity.Property(e => e.AwardDetails)
                .IsUnicode(false)
                .HasColumnName("award_details");
            entity.Property(e => e.Conditions)
                .IsUnicode(false)
                .HasColumnName("conditions");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.ImageFilePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_file_path");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.Title)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.WinnerId).HasColumnName("Winner_id");

            entity.HasOne(d => d.Winner).WithMany(p => p.Competitions)
                .HasForeignKey(d => d.WinnerId)
                .HasConstraintName("FK_Competitions_ToStudent");
        });

        modelBuilder.Entity<Exhibition>(entity =>
        {
            entity.HasKey(e => e.ExhibitionId).HasName("PK__Exhibiti__3EB7E11D099A4373");

            entity.Property(e => e.ExhibitionId).HasColumnName("exhibition_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.OrganizerDetails)
                .HasColumnType("text")
                .HasColumnName("organizer_details");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Managers__3213E83FCB4ABF90");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<PaintEx>(entity =>
        {
            entity.HasKey(e => e.PaintingExhibitionId).HasName("PK__PaintEx__5C1DADD75D4819B2");

            entity.ToTable("PaintEx");

            entity.Property(e => e.PaintingExhibitionId).HasColumnName("painting_exhibition_id");
            entity.Property(e => e.CustomerDetails)
                .HasColumnType("text")
                .HasColumnName("customer_details");
            entity.Property(e => e.ExhibitionId).HasColumnName("exhibition_id");
            entity.Property(e => e.PaintingId).HasColumnName("painting_id");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("payment_status");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.SoldPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("sold_price");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Exhibition).WithMany(p => p.PaintExes)
                .HasForeignKey(d => d.ExhibitionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaintEx__exhibit__3B75D760");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Staff__3213E83F0C391F07");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId).HasName("PK__Student__0B0245BACD6F4356");

            entity.ToTable("Student");

            entity.Property(e => e.StdId).HasColumnName("std_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.StdName).HasColumnName("std_name");
        });

        modelBuilder.Entity<Submission>(entity =>
        {
            entity.HasKey(e => e.SubmissionId).HasName("PK__Submissi__9B535595380A0E64");

            entity.Property(e => e.SubmissionId).HasColumnName("submission_id");
            entity.Property(e => e.CompetId).HasColumnName("compet_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImageFilePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_file_path");
            entity.Property(e => e.Remarks)
                .HasDefaultValueSql("('none')")
                .HasColumnType("text")
                .HasColumnName("remarks");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('pending')")
                .HasColumnName("status");
            entity.Property(e => e.StdId).HasColumnName("std_id");
            entity.Property(e => e.SubmissionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("submission_date");

            entity.HasOne(d => d.Compet).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.CompetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Submissio__compe__3C69FB99");

            entity.HasOne(d => d.Std).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.StdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Submissio__std_i__4316F928");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F52D80327");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E616481BCD06F").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572AEA1AA2A").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
