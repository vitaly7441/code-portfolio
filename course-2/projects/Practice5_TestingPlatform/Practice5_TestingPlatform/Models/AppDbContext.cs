using System;
using Microsoft.EntityFrameworkCore;
using Practice5_TestingPlatform.Enums;
using Practice5_TestingPlatform.Models;

namespace Practice5_TestingPlatform.Data {
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Direction> Directions => Set<Direction>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<TestStudent> TestStudents => Set<TestStudent>();
        public DbSet<TestProject> TestProjects => Set<TestProject>();
        public DbSet<TestCourse> TestCourses => Set<TestCourse>();
        public DbSet<TestDirection> TestDirections => Set<TestDirection>();
        public DbSet<TestGroup> TestGroups => Set<TestGroup>();
        public DbSet<Answer> Answers => Set<Answer>();
        public DbSet<Attempt> Attempts => Set<Attempt>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Test> Tests => Set<Test>();
        public DbSet<TestResult> TestResults => Set<TestResult>();
        public DbSet<UserAttemptAnswer> UserAttemptAnswers => Set<UserAttemptAnswer>();
        public DbSet<UserSelectedOption> UserSelectedOptions => Set<UserSelectedOption>();
        public DbSet<UserTextAnswer> UserTextAnswers => Set<UserTextAnswer>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.Login).IsUnique();
                e.Property(x => x.Login).IsRequired();
                e.Property(x => x.PasswordHash).IsRequired();
                e.HasIndex(x => x.Email).IsUnique();
                e.Property(x => x.Email).IsRequired();
                e.Property(x => x.FirstName).IsRequired();
                e.Property(x => x.LastName).IsRequired();
                e.Property(x => x.CreatedAt).HasDefaultValue(DateTimeOffset.UtcNow);
                
                e.HasOne(x => x.Student)
                    .WithOne(s => s.User)
                    .HasForeignKey<Student>(s => s.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Student>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Phone).HasMaxLength(30).IsRequired();
                e.Property(x => x.VkProfileLink).IsRequired();
                e.Property(x => x.VkProfileLink).IsRequired();
                e.HasIndex(x => x.UserId).IsUnique();

            });

            modelBuilder.Entity<Group>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
                e.Property(x => x.DirectionId).IsRequired();
                e.Property(x => x.CourseId).IsRequired();
                e.Property(x => x.ProjectId).IsRequired();

                e.HasOne(x => x.Direction)
                    .WithMany(d => d.Groups)
                    .HasForeignKey(x => x.DirectionId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Course)
                    .WithMany(c => c.Groups)
                    .HasForeignKey(x => x.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Project)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<TestCourse>(e =>
            {
                e.HasKey(tc => new { tc.CourseId, tc.TestId });

                e.HasOne(x => x.Course)
                    .WithMany(d => d.TestCourses)
                    .HasForeignKey(x => x.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.Test)
                    .WithMany(d => d.TestCourses)
                    .HasForeignKey(x => x.TestId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Project>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<TestProject>(e =>
            {
                e.HasKey(tc => new { tc.ProjectId, tc.TestId });

                e.HasOne(x => x.Project)
                    .WithMany(d => d.TestProject)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.Test)
                    .WithMany(d => d.TestProjects)
                    .HasForeignKey(x => x.TestId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Direction>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired();
                e.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<TestDirection>(e =>
            {
                e.HasKey(tc => new { tc.DirectionId, tc.TestId });

                e.HasOne(x => x.Direction)
                    .WithMany(d => d.TestDirection)
                    .HasForeignKey(x => x.DirectionId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(x => x.Test)
                    .WithMany(d => d.TestDirections)
                    .HasForeignKey(x => x.TestId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Test>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(x => x.Title).IsRequired();
                //e.HasIndex(x => x.Name).IsUnique();
                e.Property(x => x.Description).IsRequired();
                e.Property(e => e.IsRepeatable).HasDefaultValue(false);
                e.Property(e => e.Type)
                    .HasConversion<string>();
                e.Property(e => e.CreatedAt).HasDefaultValue(DateTimeOffset.UtcNow);
                e.Property(x => x.PublishedAt).IsRequired();
                e.Property(x => x.Deadline).IsRequired();
                e.Property(e => e.IsPublic).HasDefaultValue(false);

                e.HasMany(x => x.Questions)
                    .WithOne(d => d.Test)
                    .HasForeignKey(x => x.TestId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TestStudent>(e =>
            {
                e.HasKey(ts => new { ts.TestId, ts.StudentId });
                e.ToTable("test_students");
            });

            modelBuilder.Entity<TestProject>(e =>
            {
                e.HasKey(tp => new { tp.TestId, tp.ProjectId });
                e.ToTable("test_projects");
            });

            modelBuilder.Entity<TestCourse>(e =>
            {
                e.HasKey(tc => new { tc.TestId, tc.CourseId });
                e.ToTable("test_courses");
            });

            modelBuilder.Entity<TestGroup>(e =>
            {
                e.HasKey(tg => new { tg.TestId, tg.GroupId });
                e.ToTable("test_groups");
            });

            modelBuilder.Entity<TestDirection>(e =>
            {
                e.HasKey(td => new { td.TestId, td.DirectionId });
                e.ToTable("test_directions");
            });

            modelBuilder.Entity<Question>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(q => new { q.TestId, q.Number })
                    .IsUnique();
                e.Property(x => x.Text).IsRequired();
                e.Property(x => x.Number).IsRequired();
                e.Property(x => x.Description).HasMaxLength(2000);
                e.Property(q => q.AnswerType)
                    .HasConversion<string>()
                    .IsRequired();
                e.Property(x => x.IsScoring).HasDefaultValue(true);
                e.Property(x => x.TestId).IsRequired();

                e.HasOne(q => q.Test)
                    .WithMany(t => t.Questions)
                    .HasForeignKey(q => q.TestId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Answer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Text).IsRequired();
                e.Property(x => x.IsCorrect).IsRequired();
                e.Property(x => x.QuestionId).IsRequired();

                e.HasOne(a => a.Question)
                    .WithMany(t => t.Answers)
                    .HasForeignKey(q => q.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Attempt>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(e => e.StartedAt).HasDefaultValue(DateTimeOffset.UtcNow);
                e.Property(x => x.TestId).IsRequired();
                e.Property(x => x.StudentId).IsRequired();

                e.HasOne(a => a.Test)
                    .WithMany()
                    .HasForeignKey(q => q.TestId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(a => a.Student)
                    .WithMany()
                    .HasForeignKey(q => q.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserAttemptAnswer>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(ua => new { ua.AttemptId, ua.QuestionId })
                    .IsUnique();
                e.Property(x => x.AttemptId).IsRequired();
                e.Property(x => x.QuestionId).IsRequired();

                e.HasOne(a => a.Attempt)
                    .WithMany(a => a.UserAttemptAnswers)
                    .HasForeignKey(q => q.AttemptId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(a => a.Question)
                    .WithMany()
                    .HasForeignKey(q => q.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserSelectedOption>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.UserAttemptAnswerId).IsRequired();
                e.Property(x => x.AnswerId).IsRequired();

                e.HasOne(a => a.UserAttemptAnswer)
                    .WithMany()
                    .HasForeignKey(q => q.UserAttemptAnswerId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(a => a.Answer)
                    .WithMany()
                    .HasForeignKey(q => q.AnswerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserTextAnswer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.TextAnswer).IsRequired();
                e.Property(x => x.UserAttemptAnswerId).IsRequired();

                e.HasOne(a => a.UserAttemptAnswer)
                    .WithOne(ua => ua.UserTextAnswer)
                    .HasForeignKey<UserTextAnswer>(uta => uta.UserAttemptAnswerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TestResult>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(tr => new { tr.TestId, tr.StudentId, tr.AttemptId })
                    .IsUnique();
                e.Property(x => x.Passed).IsRequired();
                e.Property(x => x.TestId).IsRequired();
                e.Property(x => x.AttemptId).IsRequired();
                e.Property(x => x.StudentId).IsRequired();

                e.HasOne(r => r.Test)
                    .WithMany()
                    .HasForeignKey(tr => tr.TestId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.Attempt)
                    .WithMany()
                    .HasForeignKey(tr => tr.AttemptId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(r => r.Student)
                    .WithMany()
                    .HasForeignKey(tr => tr.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}