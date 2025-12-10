# Descrição do Projeto

Backend em .NET 8, estruturado em DDD (Domain-Driven Design)

Banco de dados InMemory com Entity Framework Core

Aplicação dos princípios de Clean Architecture e SOLID

O objetivo é implementar um sistema simples para cadastro de produtos, com:

✔ Listagem

✔ Criação

✔ Edição

✔ Exclusão

Todos os textos apresentados ao usuário no frontend estão em português,
enquanto nomes de classes, arquivos, variáveis e estrutura do backend estão em inglês.

🧱 Arquitetura Backend — DDD + Clean Architecture

A solução backend segue uma separação clara de responsabilidades:

```bash
backend/DesafioTotvs.

  Domain/         → Núcleo (entidades e interfaces de repositório)
  
  Application/    → Casos de uso (orquestração + DTOs + serviços)
  
  Infra/          → Infraestrutura (EF InMemory, Repositórios)
  
  Api/            → Apresentação (Controllers, DI, Swagger)

```

## 1. Domain Layer

Camada mais interna da aplicação. Contém:

Entidade Product

Regras de negócio essenciais

Interface de repositório IProductRepository

Não tem dependências com outras camadas (Clean Architecture).

## 2. Application Layer

Contém:

Casos de uso (Application Services)

Regras de orquestração da aplicação

DTOs (Data Transfer Objects)

Interface IProductAppService

Essa camada não conhece a infraestrutura, apenas depende do domínio.

## 3. Infrastructure Layer

Responsável por:

Persistência de dados usando Entity Framework Core InMemory

Implementação dos repositórios do domínio

AppDbContext (Contexto do EF)

Injeção de dependência de infraestrutura

Esta camada é facilmente substituível por SQL Server, PostgreSQL, etc.

## 4. API Layer

Camada que expõe a API REST:

Controllers (ProductsController)

Configuração de DI (Application + Infra)

Swagger/OpenAPI

Configuração de CORS para integração com Angular

### Funcionalidades Implementadas

✔ Listar todos os produtos

✔ Buscar por ID

✔ Criar produto

✔ Editar produto

✔ Excluir produto

✔ Seed inicial para teste

✔ Validações (com mensagens em português)

✔ Separação completa em camadas DDD

## A API será exposta em:
```bash
  http://localhost:5000/api/products
  https://localhost:5001/api/products
```

