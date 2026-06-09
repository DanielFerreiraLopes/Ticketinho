# 🎟️ Ticketinho

**Ticketinho** é uma API RESTful para gerenciamento de eventos e venda de ingressos, desenvolvida com **ASP.NET Core 8** seguindo os princípios de **Clean Architecture** e **Domain-Driven Design (DDD)**.

---

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias](#tecnologias)
- [Arquitetura](#arquitetura)
- [Estrutura de Pastas](#estrutura-de-pastas)
- [Funcionalidades](#funcionalidades)
- [Endpoints da API](#endpoints-da-api)
- [Configuração e Instalação](#configuração-e-instalação)
- [Banco de Dados](#banco-de-dados)
- [Diagrama de Entidades](#diagrama-de-entidades)

---

## Sobre o Projeto

O **Ticketinho** permite que administradores cadastrem eventos (shows, festas, apresentações) e que usuários comprem ingressos para esses eventos. O sistema valida disponibilidade, processa pagamentos via serviço externo e gera os ingressos associados ao pedido.

---

## Tecnologias

| Tecnologia | Versão |
|---|---|
| .NET / ASP.NET Core | 8.0 |
| Entity Framework Core | 9.0.13 |
| Pomelo EF Core MySQL | 9.0.0 |
| MySQL | — |
| Swagger / Swashbuckle | 6.6.2 |

---

## Arquitetura

O projeto adota uma estrutura modular inspirada em **Clean Architecture**, separada em dois módulos principais:

```
Eventos  →  Gerenciamento de eventos (criação, listagem, busca)
Vendas   →  Compra de ingressos, pedidos e pagamentos
```

Cada módulo possui as camadas:

```
Domain        → Entidades e Value Objects com regras de negócio
Application   → Use Cases e interfaces de repositório
Presentation  → Controllers, DTOs e interfaces de Use Case
Repositories  → Implementação dos repositórios com EF Core
```

A camada de **Infrastructure** contém as entidades mapeadas para o banco de dados e o `DbContext`.

---

## Estrutura de Pastas

```
Ticketinho/
├── Adapters/
│   └── PaymentAdapter.cs          # Integração com gateway de pagamento externo
│
├── Eventos/
│   ├── Application/
│   │   ├── Interfaces/            # IEventRepository
│   │   └── UseCases/              # CreateEvent, FindEvent, ListEvent
│   ├── Domains/
│   │   ├── Entities/              # EventDomain
│   │   └── ValueObjects/          # Name, Description, Singer, Price, Location, MaxCapacity
│   ├── Presentation/
│   │   ├── Controllers/           # EventsController
│   │   ├── DTOs/                  # CreateEventRequest, EventResponse
│   │   └── Interfaces/            # ICreateEventUseCase, IFindEventUseCase, IListEventUseCase
│   └── Repositories/              # EventRepository
│
├── Vendas/
│   ├── Application/
│   │   ├── Interfaces/            # IOrderDomainRepository, IOrderEventRepository, IOrderTicketRepository, IPaymentAdapter
│   │   └── UseCases/              # OrderTicket, FindOrder, ListOrders, GetTicketsByDocument
│   ├── Domains/
│   │   ├── Entities/              # OrderDomain, OrderEvent, OrderTicket
│   │   └── ValueObjects/          # Name, Document, Email, Quantity, Price, PaymentMethod, Status, TicketsSold
│   ├── Presentation/
│   │   ├── Controllers/           # OrderController
│   │   ├── DTOs/                  # ComprarIngressoRequest, OrderResponse, TicketResponse
│   │   └── Interfaces/            # IOrderTicketUseCase, IFindOrderUseCase, IListOrdersUseCase, IGetTicketsByDocumentUseCase
│   └── Repositories/              # OrderDomainRepository, OrderEventRepository, OrderTicketRepository
│
├── Infrastructure/
│   ├── Entities/                  # Event, Order, Ticket (mapeamento EF)
│   └── Persistence/               # OrderDbContext
│
├── Migrations/                    # Migrations do EF Core
├── Program.cs                     # Configuração de DI e pipeline HTTP
└── Ticketinho.csproj
```

---

## Funcionalidades

### Eventos
- Listar todos os eventos disponíveis
- Buscar evento por ID
- Criar novo evento (nome, descrição, artista, preço, data, capacidade, local)
- *(Em desenvolvimento)* Editar evento

### Vendas
- Comprar ingressos para um evento com processamento de pagamento
- Buscar ingressos por documento (CPF) do comprador
- Listar todos os pedidos
- Buscar pedido por ID

### Regras de Negócio
- Não é possível comprar ingressos para eventos indisponíveis ou com data passada
- A quantidade solicitada não pode ultrapassar a capacidade máxima menos os ingressos já vendidos
- O pagamento é processado via adapter externo antes de confirmar o pedido
- Cada ingresso recebe um número único gerado aleatoriamente (6 dígitos)
- O status do pedido é atualizado para **Aprovado** após confirmação do pagamento

---

## Endpoints da API

A documentação interativa está disponível via **Swagger UI** em `http://localhost:5268/swagger` ao rodar em modo desenvolvimento.

### Events — `api/Events`

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `/api/Events/ListarEventos` | Retorna todos os eventos |
| `GET` | `/api/Events/BuscarEvento?id={guid}` | Retorna um evento pelo ID |
| `POST` | `/api/Events/CriarEvento` | Cria um novo evento |
| `PUT` | `/api/Events/EditarEvento?id={guid}` | Edita um evento *(em desenvolvimento)* |

**Body — CriarEvento:**
```json
{
  "name": "Show do Artista XYZ",
  "description": "Uma noite incrível",
  "singer": "Artista XYZ",
  "price": 150.00,
  "eventDate": "2026-12-31T20:00:00",
  "maxCapacity": 500,
  "available": true,
  "location": "Arena Municipal, São Paulo"
}
```

---

### Orders — `api/Order`

| Método | Rota | Descrição |
|---|---|---|
| `POST` | `/api/Order/ComprarIngresso` | Realiza a compra de ingressos |
| `GET` | `/api/Order/BuscarPorDocumento?document={cpf}` | Busca ingressos pelo CPF do comprador |
| `GET` | `/api/Order/ListarOrders` | Retorna todos os pedidos |
| `GET` | `/api/Order/BuscarOrder?id={guid}` | Retorna um pedido pelo ID |

**Body — ComprarIngresso:**
```json
{
  "name_user": "João da Silva",
  "document_user": 12345678901,
  "email_user": "joao@email.com",
  "eventId": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
  "quantity": 2,
  "paymentMethod": "PIX"
}
```

---

## Configuração e Instalação

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- MySQL 8+ (local ou via Docker)

### Passo a passo

**1. Clone o repositório**
```bash
git clone https://github.com/DanielFerreiraLopes/Ticketinho.git
cd Ticketinho
```

**2. Configure a connection string**

No arquivo `appsettings.json`, adicione ou edite a seção:
```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost;Database=ticketinho;User=root;Password=sua_senha;"
  }
}
```

**3. Execute as migrations**
```bash
dotnet ef database update
```

**4. Rode a aplicação**
```bash
dotnet run
```

A API estará disponível em:
- HTTP: `http://localhost:5268`
- HTTPS: `https://localhost:7028`
- Swagger: `http://localhost:5268/swagger`

---

## Banco de Dados

O projeto utiliza **MySQL** com **Entity Framework Core** (provider Pomelo). As migrations já estão incluídas no repositório.

### Diagrama de Tabelas

```
Events
├── Id (PK, GUID)
├── Name
├── Description
├── Singer
├── Price
├── EventDate
├── MaxCapacity
├── TicketsSold
├── Available
└── Location

Orders
├── Id (PK, GUID)
├── Name_user
├── Document_user
├── Email_user
├── EventId (FK → Events)
├── Quantity
├── FinalPrice
├── PaymentMethod
├── Status (0 = Pendente, 1 = Aprovado)
└── DateOrder

Tickets
├── Id (PK)
├── TicketNumber
└── OrderId (FK → Orders)
```

### Relacionamentos

- Um **Event** possui muitos **Orders**
- Um **Order** possui muitos **Tickets**

---

## Integração de Pagamento

O pagamento é processado pelo `PaymentAdapter`, que realiza uma chamada HTTP POST para um serviço externo (atualmente configurado com um mock via Postman):

```
POST https://<mock-url>/enviarPagamento
Body: { orderId, amount, paymentMethod }
```

Para usar em produção, substitua a URL no `PaymentAdapter.cs` ou injete-a via configuração.



## Autor

**Daniel Ferreira Lopes e Jeann Alves** — [github.com/DanielFerreiraLopes](https://github.com/DanielFerreiraLopes)
