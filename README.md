# 🌊 FloodWatch API

**API REST para monitoramento e alerta de enchentes em tempo real**, desenvolvida em ASP.NET Core e integrada a banco de dados PostgreSQL. O projeto está 100% conteinerizado para entrega DevOps, com volume persistente e configuração segura.

👥 Integrantes
Gusthavo Daniel de Souza  — RM: 554681

Lucas Miranda Leite  — RM: 555161 

Guilherme Damasio 
Roselli  — RM: 555873

🎥 Vídeo Demonstrativo
👉 https://youtu.be/tSY9j94pFhw

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

### 🔐 Banco de Dados

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=floodwatch;Username=postgres;Password=postgres123;Port=5432"
}
🔐 JWT
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
dotnet restore
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
🐳 Usando Docker
bash
Copiar
Editar
docker-compose up -d --build
docker-compose down
🔌 Endpoints da API
🔐 Autenticação
POST /api/auth/login

POST /api/auth/register

GET /api/auth/profile

PUT /api/auth/profile

POST /api/auth/change-password

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
Disponível em:

bash
Copiar
Editar
http://localhost:8080/swagger
📦 Containerização
📁 Dockerfile (API)
Base: mcr.microsoft.com/dotnet/aspnet:8.0

Usuário não-root

Diretório de trabalho customizado

Variáveis de ambiente definidas

Porta 8080 exposta

📁 Dockerfile.db (Banco de Dados)
Base: postgres:16

Volume persistente: postgres_data

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
✅ CRUD testado via Swagger
✅ Dados persistem mesmo após reiniciar containers
✅ Logs verificados com docker logs
✅ Validação manual via psql direto no container
