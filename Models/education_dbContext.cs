using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace test1.Models
{
    public partial class education_dbContext : DbContext
    {
        public education_dbContext()
        {
        }

        public education_dbContext(DbContextOptions<education_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Clazz> Clazz { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Lecture> Lecture { get; set; }
        public virtual DbSet<Lecturer> Lecturer { get; set; }
        public virtual DbSet<StdCount> StdCount { get; set; }
        public virtual DbSet<StdView> StdView { get; set; }
        public virtual DbSet<StdVieww> StdVieww { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teaching> Teaching { get; set; }
        public virtual DbSet<View3> View3 { get; set; }
        public virtual DbSet<View4> View4 { get; set; }
        public virtual DbSet<ViewStudent> ViewStudent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=education_db;Pooling=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>(entity =>
            {
                entity.ToTable("cars");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Clazz>(entity =>
            {
                entity.ToTable("clazz");

                entity.Property(e => e.ClazzId)
                    .HasColumnName("clazz_id")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.LectureId)
                    .HasColumnName("lecture_id")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MonitorId)
                    .HasColumnName("monitor_id")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.NumberStd)
                    .HasColumnName("number_std")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Clazz)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("fk_clazz_lecture_id");

                entity.HasOne(d => d.Monitor)
                    .WithMany(p => p.Clazz)
                    .HasForeignKey(d => d.MonitorId)
                    .HasConstraintName("fk_monitor_id");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.SubjectId, e.Semester })
                    .HasName("pk_enrollment");

                entity.ToTable("enrollment");

                entity.Property(e => e.StudentId)
                    .HasColumnName("student_id")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subject_id")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Semester)
                    .HasColumnName("semester")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.FinalScore).HasColumnName("final_score");

                entity.Property(e => e.MidtermScore).HasColumnName("midterm_score");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enrollment_fk_student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enrollment_fk_subject");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("pk_grade_code");

                entity.ToTable("grade");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.FromScore)
                    .HasColumnName("from_score")
                    .HasColumnType("numeric(3,1)");

                entity.Property(e => e.ToScore)
                    .HasColumnName("to_score")
                    .HasColumnType("numeric(3,1)");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.ToTable("lecture");

                entity.Property(e => e.LectureId)
                    .HasColumnName("lecture_id")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(30);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.ToTable("lecturer");

                entity.Property(e => e.LecturerId)
                    .HasColumnName("lecturer_id")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(30);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(40);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<StdCount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("std_count");

                entity.Property(e => e.ClazzId)
                    .HasColumnName("clazz_id")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.NumberStd).HasColumnName("number_std");
            });

            modelBuilder.Entity<StdView>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("std_view");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(30);

                entity.Property(e => e.ClazzId)
                    .HasColumnName("clazz_id")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.StudentId)
                    .HasColumnName("student_id")
                    .HasMaxLength(8)
                    .IsFixedLength();
            });

            modelBuilder.Entity<StdVieww>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("std_vieww");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(20);

                entity.Property(e => e.StudentId)
                    .HasColumnName("student_id")
                    .HasMaxLength(8)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.StudentId)
                    .HasColumnName("student_id")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(30);

                entity.Property(e => e.ClazzId)
                    .HasColumnName("clazz_id")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Note).HasColumnName("note");

                entity.HasOne(d => d.ClazzNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ClazzId)
                    .HasConstraintName("student_fk_class");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subject_id")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Credit).HasColumnName("credit");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);

                entity.Property(e => e.PercentageFinalExam).HasColumnName("percentage_final_exam");
            });

            modelBuilder.Entity<Teaching>(entity =>
            {
                entity.HasKey(e => new { e.SubjectId, e.LectureId })
                    .HasName("pk_teaching");

                entity.ToTable("teaching");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subject_id")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.LectureId)
                    .HasColumnName("lecture_id")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_teaching_lecture_id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teaching_fk_subject");
            });

            modelBuilder.Entity<View3>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("view_3");

                entity.Property(e => e.ClazzId)
                    .HasColumnName("clazz_id")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<View4>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("view_4");

                entity.Property(e => e.ClazzId)
                    .HasColumnName("clazz_id")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ViewStudent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("view_student");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(30);

                entity.Property(e => e.ClazzId)
                    .HasColumnName("clazz_id")
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.StudentId)
                    .HasColumnName("student_id")
                    .HasMaxLength(8)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
