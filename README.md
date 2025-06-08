# Pokemon API

API RESTful para integração com a [PokeAPI](https://pokeapi.co/), persistência de dados em SQLite e gerenciamento de mestres pokémon, seguindo o padrão Clean Architecture.

---

## Sumário

- [Estrutura do Projeto](#estrutura-do-projeto)
- [Endpoints](#endpoints)
  - [Pokémon](#pokémon)
  - [Mestre Pokémon](#mestre-pokémon)
- [Como Rodar o Projeto](#como-rodar-o-projeto)
  - [Pré-requisitos](#pré-requisitos)
  - [Configuração do Banco de Dados](#configuração-do-banco-de-dados)
  - [Executando as Migrations](#executando-as-migrations)
  - [Executando a API](#executando-a-api)
- [Observações](#observações)

---

## Estrutura do Projeto

O projeto segue o padrão **Clean Architecture**, dividido em:

- **Pokemon.Api**: Camada de apresentação (controllers, endpoints REST, configuração do Swagger).
- **Pokemon.Application**: Casos de uso (use cases), DTOs de request/result, regras de aplicação.
- **Pokemon.Domain**: Entidades de domínio, interfaces de repositórios e serviços.
- **Pokemon.Infrastructure.PokeClient**: Integração com a PokeAPI usando Refit.
- **Pokemon.Infrastructure.Data**: Persistência de dados com Entity Framework Core e SQLite.

---

## Endpoints

### Pokémon

#### `GET /api/pokemon`
Retorna uma lista paginada de pokémons da PokeAPI.

- **Parâmetros de query:**
  - `offset` (opcional): deslocamento do primeiro item (padrão: 0)
  - `limit` (opcional): quantidade máxima de itens (padrão: 20)
- **Resposta:**  
  `200 OK`

---

#### `GET /api/pokemon/{name}`
Retorna os detalhes de um pokémon específico pelo nome.

- **Parâmetro de rota:**  
  - `name`: nome do pokémon
- **Resposta:**  
  `200 OK` com detalhes do pokémon  
  `404 Not Found` se não encontrado

---

#### `POST /api/pokemon/capturar`
Captura um pokémon para um mestre, integrando com a PokeAPI e salvando na base local.

- **Body:**
- **Resposta:**  
  `201 Created` com dados do pokémon capturado  
  `404 Not Found` se o pokémon não for encontrado na PokeAPI

---

#### `GET /api/pokemon/capturados`
Lista os pokémons capturados na base de dados, paginado.

- **Parâmetros de query:**
  - `page` (opcional): número da página (padrão: 1)
  - `pageSize` (opcional): tamanho da página (padrão: 10)
- **Resposta:**  
  `200 OK` com lista paginada dos pokémons capturados

---

### Mestre Pokémon

#### `POST /api/mestrepokemon`
Adiciona um novo mestre pokémon.

- **Body:**
- **Resposta:**  
  `201 Created` com dados do mestre criado

---

#### `PUT /api/mestrepokemon`
Atualiza um mestre pokémon existente.

- **Body:**
- **Resposta:**  
  `200 OK` com dados atualizados  
  `404 Not Found` se não encontrado

---

#### `DELETE /api/mestrepokemon/{id}`
Remove um mestre pokémon pelo id.

- **Parâmetro de rota:**  
  - `id`: GUID do mestre
- **Resposta:**  
  `204 No Content`  
  `404 Not Found` se não encontrado

---

#### `GET /api/mestrepokemon/{id}`
Obtém um mestre pokémon pelo id.

- **Parâmetro de rota:**  
  - `id`: GUID do mestre
- **Resposta:**  
  `200 OK` com dados do mestre  
  `404 Not Found` se não encontrado

---

#### `GET /api/mestrepokemon`
Lista todos os mestres pokémon paginados.

- **Parâmetros de query:**
  - `page` (opcional): número da página (padrão: 1)
  - `pageSize` (opcional): tamanho da página (padrão: 10)
- **Resposta:**  
  `200 OK` com lista paginada dos mestres

---

## Como Rodar o Projeto

### Pré-requisitos

- Visual Studio 2022 ou superior
- .NET 9 SDK
- (Opcional) [EF Core Tools](https://learn.microsoft.com/ef/core/cli/dotnet) para migrations

---

### Configuração do Banco de Dados

No arquivo `appsettings.json` do projeto `Pokemon.Api`, adicione:
```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Data Source=pokemon.db"
  }
}
```

---

### Executando as Migrations

1. Abra o **Package Manager Console** no Visual Studio.
2. Execute: 
   ```
   Add-Migration InitialCreate -Project Pokemon.Infrastructure.Data -StartupProject Pokemon.Api
   ```
   Isso criará a migration inicial para o banco de dados SQLite.
3. Depois, aplique a migration: 
   ```
   Update-Database -Project Pokemon.Infrastructure.Data -StartupProject Pokemon.Api
   ```

---

### Executando a API

1. No Visual Studio, selecione o projeto de inicialização `Pokemon.Api`.
2. Pressione **F5** ou clique em **Iniciar**.
3. Acesse o Swagger em `https://localhost:{porta}/swagger` para testar os endpoints.

---

## Observações

- O projeto segue Clean Architecture, separando responsabilidades em camadas.
- A integração com a PokeAPI é feita via Refit.
- O banco de dados local é SQLite, facilmente portável para outros providers.
- Todos os endpoints estão documentados no Swagger.

---

**Dúvidas ou sugestões? Abra uma issue ou entre em contato!**