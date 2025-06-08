# FloodWatch API

API REST para o sistema FloodWatch de monitoramento e alerta de enchentes em tempo real.

## Tecnologias Utilizadas

- ASP.NET Core 8.0
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- Swagger/OpenAPI
- Docker

## Estrutura do Projeto

```
FloodWatch.API/
├── Controllers/       # Controladores da API
├── Models/            # Modelos de dados
├── DTOs/              # Data Transfer Objects
├── Services/          # Serviços de negócio
├── Repositories/      # Repositórios de dados
├── Data/              # Contexto do Entity Framework
├── Migrations/        # Migrações do banco de dados
├── Middleware/        # Middlewares personalizados
├── Configuration/     # Classes de configuração
└── Dockerfile         # Configuração para containerização
```

## Requisitos

- .NET 8.0 SDK
- PostgreSQL
- Docker (opcional)

## Configuração

### Configuração do Banco de Dados

A string de conexão está configurada no arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=floodwatch;Username=postgres;Password=postgres123;Port=5432"
}
```

### Configuração JWT

```json
"JwtSettings": {
  "SecretKey": "FloodWatch2025SecretKeyForJWTTokenGeneration123456789",
  "Issuer": "FloodWatch.API",
  "Audience": "FloodWatch.Client",
  "ExpirationHours": 24
}
```

## Executando o Projeto

### Usando .NET CLI

```bash
# Restaurar pacotes
dotnet restore

# Compilar o projeto
dotnet build

# Criar migrations
dotnet ef migrations add InitialCreate

# Aplicar migrations
dotnet ef database update

# Executar o projeto
dotnet run
```

### Usando Docker

```bash
# Construir e iniciar os containers
docker-compose up -d

# Parar os containers
docker-compose down
```

## Endpoints da API

### Autenticação

- POST /api/auth/login - Login de usuário
- POST /api/auth/register - Registro de usuário
- GET /api/auth/profile - Obter perfil do usuário
- PUT /api/auth/profile - Atualizar perfil do usuário
- POST /api/auth/change-password - Alterar senha

### Sensores

- GET /api/sensores - Listar todos os sensores
- GET /api/sensores/{id} - Obter sensor por ID
- POST /api/sensores - Criar novo sensor
- PUT /api/sensores/{id} - Atualizar sensor
- DELETE /api/sensores/{id} - Remover sensor
- GET /api/sensores/{id}/leituras - Obter leituras de um sensor

### Regiões

- GET /api/regioes - Listar todas as regiões
- GET /api/regioes/{id} - Obter região por ID
- POST /api/regioes - Criar nova região
- PUT /api/regioes/{id} - Atualizar região
- DELETE /api/regioes/{id} - Remover região

### Leituras

- GET /api/leituras - Listar leituras com filtros
- POST /api/leituras - Registrar nova leitura
- GET /api/leituras/tempo-real - Obter leituras em tempo real

### Alertas

- GET /api/alertas - Listar alertas ativos
- GET /api/alertas/{id} - Obter alerta por ID
- POST /api/alertas - Criar novo alerta
- PUT /api/alertas/{id} - Atualizar alerta
- DELETE /api/alertas/{id} - Cancelar alerta

## Documentação da API

A documentação da API está disponível através do Swagger UI, acessível na raiz da aplicação quando em execução.

## Containerização

O projeto inclui um Dockerfile e um arquivo docker-compose.yml para facilitar a containerização e execução em ambientes Docker.

### Dockerfile

O Dockerfile segue as melhores práticas:
- Usa imagem oficial do .NET 8.0
- Executa com usuário não-root
- Utiliza multi-stage build para otimização
- Expõe as portas necessárias
- Configura variáveis de ambiente

### Docker Compose

O docker-compose.yml configura:
- Serviço da API FloodWatch
- Banco de dados PostgreSQL
- Rede compartilhada
- Volume persistente para dados do PostgreSQL

