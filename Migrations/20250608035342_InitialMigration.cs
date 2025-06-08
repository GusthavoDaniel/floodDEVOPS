using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FloodWatch.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ultimo_acesso = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    endereco = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    latitude = table.Column<decimal>(type: "numeric(10,8)", precision: 10, scale: 8, nullable: true),
                    longitude = table.Column<decimal>(type: "numeric(11,8)", precision: 11, scale: 8, nullable: true),
                    receber_notificacoes = table.Column<bool>(type: "boolean", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "regioes_cobertas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    nivel_risco_atual = table.Column<int>(type: "integer", nullable: false),
                    populacao_estimada = table.Column<int>(type: "integer", nullable: false),
                    area_km2 = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regioes_cobertas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_claims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_logins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_logins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_user_logins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_tokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_user_tokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alertas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    regiao_coberta_id = table.Column<int>(type: "integer", nullable: false),
                    tipo_alerta = table.Column<int>(type: "integer", nullable: false),
                    titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    descricao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    data_hora_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_hora_expiracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    usuario_criador_id = table.Column<int>(type: "integer", nullable: false),
                    nivel_severidade = table.Column<int>(type: "integer", nullable: false),
                    instrucoes_seguranca = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    raio_afetado_km = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: true),
                    pessoas_afetadas_estimadas = table.Column<int>(type: "integer", nullable: true),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alertas", x => x.id);
                    table.ForeignKey(
                        name: "FK_alertas_AspNetUsers_usuario_criador_id",
                        column: x => x.usuario_criador_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_alertas_regioes_cobertas_regiao_coberta_id",
                        column: x => x.regiao_coberta_id,
                        principalTable: "regioes_cobertas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historico_eventos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    regiao_coberta_id = table.Column<int>(type: "integer", nullable: false),
                    tipo_evento = table.Column<int>(type: "integer", nullable: false),
                    data_hora_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_hora_fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    nivel_severidade = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    pessoas_afetadas = table.Column<int>(type: "integer", nullable: true),
                    danos_estimados = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: true),
                    area_afetada_km2 = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: true),
                    nivel_agua_maximo = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: true),
                    precipitacao_total = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: true),
                    acoes_tomadas = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    licoes_aprendidas = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historico_eventos", x => x.id);
                    table.ForeignKey(
                        name: "FK_historico_eventos_regioes_cobertas_regiao_coberta_id",
                        column: x => x.regiao_coberta_id,
                        principalTable: "regioes_cobertas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sensores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    latitude = table.Column<decimal>(type: "numeric(10,8)", precision: 10, scale: 8, nullable: false),
                    longitude = table.Column<decimal>(type: "numeric(11,8)", precision: 11, scale: 8, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    data_instalacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ultima_leitura = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    regiao_coberta_id = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    intervalo_leitura_minutos = table.Column<int>(type: "integer", nullable: false),
                    valor_minimo = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: true),
                    valor_maximo = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: true),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensores", x => x.id);
                    table.ForeignKey(
                        name: "FK_sensores_regioes_cobertas_regiao_coberta_id",
                        column: x => x.regiao_coberta_id,
                        principalTable: "regioes_cobertas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_role_claims_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_user_roles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "leituras_sensor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sensor_id = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<decimal>(type: "numeric(10,4)", precision: 10, scale: 4, nullable: false),
                    unidade_medida = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    data_hora_leitura = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status_qualidade = table.Column<int>(type: "integer", nullable: false),
                    observacoes = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    temperatura_ambiente = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    umidade_relativa = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    pressao_atmosferica = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: true),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leituras_sensor", x => x.id);
                    table.ForeignKey(
                        name: "FK_leituras_sensor_sensores_sensor_id",
                        column: x => x.sensor_id,
                        principalTable: "sensores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "regioes_cobertas",
                columns: new[] { "id", "area_km2", "data_atualizacao", "data_criacao", "descricao", "nivel_risco_atual", "nome", "populacao_estimada" },
                values: new object[,]
                {
                    { 1, 25.5m, new DateTime(2024, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Região central da cidade de São Paulo", 2, "Centro de São Paulo", 500000 },
                    { 2, 45.2m, new DateTime(2024, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Região da zona sul de São Paulo", 1, "Zona Sul - SP", 800000 }
                });

            migrationBuilder.InsertData(
                table: "sensores",
                columns: new[] { "id", "data_atualizacao", "data_criacao", "data_instalacao", "descricao", "intervalo_leitura_minutos", "latitude", "longitude", "nome", "regiao_coberta_id", "status", "tipo", "ultima_leitura", "valor_maximo", "valor_minimo" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 5, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Sensor de nível de água no Vale do Anhangabaú", 15, -23.5489m, -46.6388m, "Sensor Anhangabaú", 1, 1, 1, null, 5m, 0m },
                    { 2, new DateTime(2024, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 4, 15, 10, 0, 0, 0, DateTimeKind.Utc), "Sensor de precipitação no Parque Ibirapuera", 10, -23.5873m, -46.6573m, "Sensor Ibirapuera", 2, 1, 2, null, 100m, 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_alertas_data_hora_criacao",
                table: "alertas",
                column: "data_hora_criacao");

            migrationBuilder.CreateIndex(
                name: "IX_alertas_regiao_coberta_id",
                table: "alertas",
                column: "regiao_coberta_id");

            migrationBuilder.CreateIndex(
                name: "IX_alertas_status",
                table: "alertas",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_alertas_usuario_criador_id",
                table: "alertas",
                column: "usuario_criador_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_historico_eventos_data_hora_inicio",
                table: "historico_eventos",
                column: "data_hora_inicio");

            migrationBuilder.CreateIndex(
                name: "IX_historico_eventos_regiao_coberta_id",
                table: "historico_eventos",
                column: "regiao_coberta_id");

            migrationBuilder.CreateIndex(
                name: "IX_historico_eventos_tipo_evento",
                table: "historico_eventos",
                column: "tipo_evento");

            migrationBuilder.CreateIndex(
                name: "IX_leituras_sensor_sensor_id_data_hora_leitura",
                table: "leituras_sensor",
                columns: new[] { "sensor_id", "data_hora_leitura" });

            migrationBuilder.CreateIndex(
                name: "IX_regioes_cobertas_nome",
                table: "regioes_cobertas",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_claims_RoleId",
                table: "role_claims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sensores_nome",
                table: "sensores",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "IX_sensores_regiao_coberta_id",
                table: "sensores",
                column: "regiao_coberta_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_claims_UserId",
                table: "user_claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_logins_UserId",
                table: "user_logins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_RoleId",
                table: "user_roles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alertas");

            migrationBuilder.DropTable(
                name: "historico_eventos");

            migrationBuilder.DropTable(
                name: "leituras_sensor");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_logins");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "sensores");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "regioes_cobertas");
        }
    }
}
