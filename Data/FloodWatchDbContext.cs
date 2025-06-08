using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FloodWatch.API.Models;

namespace FloodWatch.API.Data
{
    public class FloodWatchDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {
        public FloodWatchDbContext(DbContextOptions<FloodWatchDbContext> options) : base(options)
        {
        }

        // Construtor para design-time (migrations)
        public FloodWatchDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=floodwatch;Username=postgres;Password=postgres123;Port=5432");
            }
        }

        public DbSet<RegiaoCoberta> RegioesCoberta { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<LeituraSensor> LeiturasSensor { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<HistoricoEvento> HistoricoEventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações das entidades
            ConfigureRegiaoCoberta(modelBuilder);
            ConfigureSensor(modelBuilder);
            ConfigureLeituraSensor(modelBuilder);
            ConfigureAlerta(modelBuilder);
            ConfigureHistoricoEvento(modelBuilder);
            ConfigureUsuario(modelBuilder);

            // Seed data
            SeedData(modelBuilder);
        }

        private void ConfigureRegiaoCoberta(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegiaoCoberta>(entity =>
            {
                entity.HasIndex(e => e.Nome).IsUnique();
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.AreaKm2).HasPrecision(10, 4);
            });
        }

        private void ConfigureSensor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.HasIndex(e => e.Nome);
                entity.Property(e => e.Latitude).HasPrecision(10, 8);
                entity.Property(e => e.Longitude).HasPrecision(11, 8);
                entity.Property(e => e.ValorMinimo).HasPrecision(10, 4);
                entity.Property(e => e.ValorMaximo).HasPrecision(10, 4);

                entity.HasOne(s => s.RegiaoCoberta)
                      .WithMany(r => r.Sensores)
                      .HasForeignKey(s => s.RegiaoCobertaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureLeituraSensor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeituraSensor>(entity =>
            {
                entity.HasIndex(e => new { e.SensorId, e.DataHoraLeitura });
                entity.Property(e => e.Valor).HasPrecision(10, 4);
                entity.Property(e => e.TemperaturaAmbiente).HasPrecision(5, 2);
                entity.Property(e => e.UmidadeRelativa).HasPrecision(5, 2);
                entity.Property(e => e.PressaoAtmosferica).HasPrecision(8, 2);

                entity.HasOne(l => l.Sensor)
                      .WithMany(s => s.Leituras)
                      .HasForeignKey(l => l.SensorId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureAlerta(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alerta>(entity =>
            {
                entity.HasIndex(e => e.DataHoraCriacao);
                entity.HasIndex(e => e.Status);
                entity.Property(e => e.RaioAfetadoKm).HasPrecision(8, 2);

                entity.HasOne(a => a.RegiaoCoberta)
                      .WithMany(r => r.Alertas)
                      .HasForeignKey(a => a.RegiaoCobertaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.UsuarioCriador)
                      .WithMany(u => u.AlertasCriados)
                      .HasForeignKey(a => a.UsuarioCriadorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureHistoricoEvento(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoricoEvento>(entity =>
            {
                entity.HasIndex(e => e.DataHoraInicio);
                entity.HasIndex(e => e.TipoEvento);
                entity.Property(e => e.DanosEstimados).HasPrecision(15, 2);
                entity.Property(e => e.AreaAfetadaKm2).HasPrecision(10, 4);
                entity.Property(e => e.NivelAguaMaximo).HasPrecision(8, 2);
                entity.Property(e => e.PrecipitacaoTotal).HasPrecision(8, 2);

                entity.HasOne(h => h.RegiaoCoberta)
                      .WithMany(r => r.HistoricoEventos)
                      .HasForeignKey(h => h.RegiaoCobertaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureUsuario(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Latitude).HasPrecision(10, 8);
                entity.Property(e => e.Longitude).HasPrecision(11, 8);
            });

            // Configurar tabelas do Identity
            modelBuilder.Entity<IdentityRole<int>>().ToTable("roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("user_logins");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("user_tokens");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("role_claims");
        }

       private void SeedData(ModelBuilder modelBuilder)
{
    var dataFixaCriacao = new DateTime(2024, 06, 01, 12, 00, 00, DateTimeKind.Utc);
    var dataInstalacao1 = new DateTime(2024, 05, 01, 08, 00, 00, DateTimeKind.Utc);
    var dataInstalacao2 = new DateTime(2024, 04, 15, 10, 00, 00, DateTimeKind.Utc);

    // Regiões
    modelBuilder.Entity<RegiaoCoberta>().HasData(
        new RegiaoCoberta
        {
            Id = 1,
            Nome = "Centro de São Paulo",
            Descricao = "Região central da cidade de São Paulo",
            NivelRiscoAtual = NivelRisco.Medio,
            PopulacaoEstimada = 500000,
            AreaKm2 = 25.5m,
            DataCriacao = dataFixaCriacao,
            DataAtualizacao = dataFixaCriacao
        },
        new RegiaoCoberta
        {
            Id = 2,
            Nome = "Zona Sul - SP",
            Descricao = "Região da zona sul de São Paulo",
            NivelRiscoAtual = NivelRisco.Baixo,
            PopulacaoEstimada = 800000,
            AreaKm2 = 45.2m,
            DataCriacao = dataFixaCriacao,
            DataAtualizacao = dataFixaCriacao
        }
    );

    // Sensores
    modelBuilder.Entity<Sensor>().HasData(
        new Sensor
        {
            Id = 1,
            Nome = "Sensor Anhangabaú",
            Tipo = TipoSensor.NivelAgua,
            Latitude = -23.5489m,
            Longitude = -46.6388m,
            Status = StatusSensor.Ativo,
            DataInstalacao = dataInstalacao1,
            RegiaoCobertaId = 1,
            Descricao = "Sensor de nível de água no Vale do Anhangabaú",
            IntervaloLeituraMinutos = 15,
            ValorMinimo = 0m,
            ValorMaximo = 5m,
            DataCriacao = dataFixaCriacao,
            DataAtualizacao = dataFixaCriacao
        },
        new Sensor
        {
            Id = 2,
            Nome = "Sensor Ibirapuera",
            Tipo = TipoSensor.Precipitacao,
            Latitude = -23.5873m,
            Longitude = -46.6573m,
            Status = StatusSensor.Ativo,
            DataInstalacao = dataInstalacao2,
            RegiaoCobertaId = 2,
            Descricao = "Sensor de precipitação no Parque Ibirapuera",
            IntervaloLeituraMinutos = 10,
            ValorMinimo = 0m,
            ValorMaximo = 100m,
            DataCriacao = dataFixaCriacao,
            DataAtualizacao = dataFixaCriacao
        }
    );
}
        }
    }


