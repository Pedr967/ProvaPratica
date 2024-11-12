using Microsoft.EntityFrameworkCore;

namespace prova2{
    public class AppDbContext : DbContext{
        public DbSet<Aluno> Alunos {get; set;}
        public DbSet<Disciplina> Disciplinas {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=prova.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasMany(d => d.Disciplinas)
                .WithMany(a => a.Alunos)
                .UsingEntity(j => j.ToTable("AlunoDisciplinas"));
        }
    }
}