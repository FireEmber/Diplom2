using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Diplom.DataBase;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Discipline> Disciplines { get; set; }

    public virtual DbSet<FalseAnswer> FalseAnswers { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestDiscription> TestDiscriptions { get; set; }

    public virtual DbSet<TestScore> TestScores { get; set; }

    public virtual DbSet<TrueAnswer> TrueAnswers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8TAO8OB;DataBase=MarininV3;Trusted_Connection=true;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC27531E5CBE");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__Role__398D8EEE");
        });

        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discipli__3214EC27A4335D8B");

            entity.ToTable("Discipline");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tittle).HasMaxLength(50);

            entity.HasOne(d => d.TeacherNavigation).WithMany(p => p.Disciplines)
                .HasForeignKey(d => d.Teacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Disciplin__Teach__3F466844");
        });

        modelBuilder.Entity<FalseAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FalseAns__3214EC2713C99CF4");

            entity.ToTable("FalseAnswer");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC271D0AD7D1");

            entity.ToTable("Question");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Question1).HasColumnName("Question");

            entity.HasOne(d => d.FalseAnswerNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.FalseAnswer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Question__FalseA__47DBAE45");

            entity.HasOne(d => d.TestNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.Test)
                .HasConstraintName("FK__Question__Test__60A75C0F");

            entity.HasOne(d => d.TrueAnswerNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TrueAnswer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Question__TrueAn__48CFD27E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC2717BB6DCE");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC276F8E2D17");

            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fio).HasColumnName("FIO");

            entity.HasOne(d => d.AccountNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Account)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__Account__5070F446");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3214EC274B4C6F9E");

            entity.ToTable("Teacher");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fio).HasColumnName("FIO");

            entity.HasOne(d => d.AccountNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.Account)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Teacher__Account__3C69FB99");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Test__3214EC273D5C4391");

            entity.ToTable("Test");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.DisciplineNavigation).WithMany(p => p.Tests)
                .HasForeignKey(d => d.Discipline)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Test__Discipline__4D94879B");

            entity.HasOne(d => d.DiscriptionNavigation).WithMany(p => p.Tests)
                .HasForeignKey(d => d.Discription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Test__Discriptio__4BAC3F29");
        });

        modelBuilder.Entity<TestDiscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TestDisc__3214EC2767632E8B");

            entity.ToTable("TestDiscription");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<TestScore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TestScor__3214EC275D38B0DF");

            entity.ToTable("TestScore");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TestScore1).HasColumnName("TestScore");

            entity.HasOne(d => d.StudentNavigation).WithMany(p => p.TestScores)
                .HasForeignKey(d => d.Student)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TestScore__Stude__534D60F1");

            entity.HasOne(d => d.TestNavigation).WithMany(p => p.TestScores)
                .HasForeignKey(d => d.Test)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TestScore__Test__5441852A");
        });

        modelBuilder.Entity<TrueAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TrueAnsw__3214EC279221C782");

            entity.ToTable("TrueAnswer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TrueAnswer1).HasColumnName("TrueAnswer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
