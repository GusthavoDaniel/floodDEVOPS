# 🌊 FloodWatch API

**API REST para monitoramento e alerta de enchentes em tempo real**, desenvolvida em ASP.NET Core e integrada a banco de dados PostgreSQL. O projeto está 100% conteinerizado para entrega DevOps, com volume persistente e configuração segura.

---

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **PostgreSQL**
- **JWT Authentication**
- **Swagger / OpenAPI**
- **Docker + Docker Compose**

---

## 🗂️ Estrutura do Projeto

FloodWatch.API/
├── Controllers/ # Controladores da API
├── Models/ # Modelos de dados
├── DTOs/ # Data Transfer Objects
├── Services/ # Lógica de negócios
├── Repositories/ # Acesso a dados
├── Data/ # DbContext do EF Core
├── Migrations/ # Histórico de migrações
├── Middleware/ # Middlewares customizados
├── Configuration/ # Configurações e injeção
├── Dockerfile # Dockerfile da aplicação
docker-compose.yml # Orquestração dos serviços

yaml
Copiar
Editar

---

## ⚙️ Configuração

### 🔐 Configuração do Banco de Dados

No `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=floodwatch;Username=postgres;Password=postgres123;Port=5432"
}
🔐 Configuração JWT
json
Copiar
Editar
"JwtSettings": {
  "SecretKey": "FloodWatch2025SecretKeyForJWTTokenGeneration123456789",
  "Issuer": "FloodWatch.API",
  "Audience": "FloodWatch.Client",
  "ExpirationHours": 24
}
▶️ Executando o Projeto
✅ Usando .NET CLI (sem Docker)
bash
Copiar
Editar
# Restaurar pacotes
dotnet restore

# Compilar
dotnet build

# Criar a base de dados com migrações
dotnet ef migrations add InitialCreate
dotnet ef database update

# Executar
dotnet run
🐳 Usando Docker
bash
Copiar
Editar
# Subir containers com volume persistente e rede customizada
docker-compose up -d --build

# Parar os serviços
docker-compose down
🔌 Endpoints da API
🔐 Autenticação
POST /api/auth/login — Login

POST /api/auth/register — Cadastro

GET /api/auth/profile — Perfil do usuário

PUT /api/auth/profile — Atualizar perfil

POST /api/auth/change-password — Trocar senha

📡 Sensores
GET /api/sensores

GET /api/sensores/{id}

POST /api/sensores

PUT /api/sensores/{id}

DELETE /api/sensores/{id}

GET /api/sensores/{id}/leituras

🌎 Regiões
GET /api/regioes

GET /api/regioes/{id}

POST /api/regioes

PUT /api/regioes/{id}

DELETE /api/regioes/{id}

📊 Leituras
GET /api/leituras

GET /api/leituras/tempo-real

POST /api/leituras

🚨 Alertas
GET /api/alertas

GET /api/alertas/{id}

POST /api/alertas

PUT /api/alertas/{id}

DELETE /api/alertas/{id}

📃 Documentação Swagger
Disponível automaticamente ao rodar o projeto:

bash
Copiar
Editar
http://localhost:8080/swagger
📦 Containerização
📁 Dockerfile (Aplicação)
Baseado em imagem oficial .NET 8.0 SDK/Runtime

Usuário não-root

WORKDIR configurado

Variáveis de ambiente

Porta 8080 exposta

📁 Dockerfile (Banco de Dados)
Imagem baseada em postgres:16

Volume nomeado: postgres_data

Variáveis: POSTGRES_DB, POSTGRES_USER, POSTGRES_PASSWORD

Porta exposta: 5432

⚙️ docker-compose.yml
yaml
Copiar
Editar
services:
  api:
    build: .
    ports:
      - "8080:8080"
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
    depends_on:
      - db
    networks:
      - floodwatchnet

  db:
    build:
      context: .
      dockerfile: Dockerfile.db
    environment:
      POSTGRES_DB: floodwatchdb
      POSTGRES_USER: devuser
      POSTGRES_PASSWORD: devpass
    volumes:
      - postgres_data:/var/lib/postgresql/data
    ports:
      - "5432:5432"
    networks:
      - floodwatchnet

networks:
  floodwatchnet:

volumes:
  postgres_data:
🧪 Testes CRUD e Logs
✅ Operações testadas no Swagger UI

✅ Logs da aplicação disponíveis via docker logs

✅ Dados persistem após reiniciar os containers

✅ Dados verificados diretamente via psql
