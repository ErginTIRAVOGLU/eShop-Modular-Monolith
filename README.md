# eShop Modular Monolith

This repository contains a modular monolith implementation of an e-commerce sample built with ASP.NET Core. It is organized into independent modules for Catalog, Basket, and Ordering, while sharing infrastructure concerns such as messaging, persistence, validation, logging, and cross-cutting behaviors.

## Overview

The solution demonstrates a modular architecture in a single deployable application, combining:

- ASP.NET Core Web API hosting
- Carter for endpoint routing
- MediatR for command/query handling
- Entity Framework Core with PostgreSQL
- Redis for distributed caching
- RabbitMQ via MassTransit for messaging
- Serilog with Seq for structured logging
- Keycloak for authentication and identity

## Solution Structure

- Bootstrapper/Api: API host and composition root
- Modules/Catalog: catalog-related domain and data access
- Modules/Basket: basket domain, repository, and outbox processing
- Modules/Ordering: ordering domain and persistence
- Shared: shared contracts, behaviors, exceptions, pagination, and messaging infrastructure

## Technologies

- .NET 10
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Redis
- RabbitMQ
- MassTransit
- Serilog
- Seq
- Keycloak

## Prerequisites

Before running the application, make sure you have:

- Docker Desktop
- .NET SDK 10.0 or later
- A terminal with access to dotnet and docker

## Running the Infrastructure

From the repository root, start the supporting services:

```bash
cd src
docker compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

If you want to run Seq separately, you can also use:

```bash
docker run -d --name seq -e ACCEPT_EULA=Y -p 5341:80 datalust/seq
```

## Running the API

Run the API from the project folder:

```bash
cd src/Bootstrapper/Api
dotnet run
```

The API will typically be available at:

- http://localhost:5000
- https://localhost:5050

## Database Migrations

The solution uses EF Core migrations per module. Run the following commands from the API project folder:

```bash
cd src/Bootstrapper/Api
```

### Basket module

```bash
dotnet ef migrations add AddedOutboxMessage -o Data/Migrations -p ..\..\Modules\Basket\Basket\Basket.csproj -s .\Api.csproj -c BasketDbContext
dotnet ef database update -c BasketDbContext
```

### Ordering module

```bash
dotnet ef migrations add InitialCreate -o Data/Migrations -p ..\..\Modules\Ordering\Ordering\Ordering.csproj -s .\Api.csproj -c OrderingDbContext
```

## Keycloak and Authentication

The application is configured to work with a local Keycloak instance.

Useful local endpoints:

- Realm account console: http://localhost:9090/realms/myrealm/account/
- Token endpoint: http://localhost:9090/realms/myrealm/protocol/openid-connect/token

## Observability and Admin UIs

- Seq: http://localhost:5341 (when using the standalone Seq container) or http://localhost:9091 (when using the compose override setup)
- RabbitMQ UI: http://localhost:15672
- pgAdmin: http://localhost:9999

## Default Credentials

- PostgreSQL: postgres / postgres
- RabbitMQ: guest / guest
- Keycloak admin: admin / admin
- pgAdmin: admin@admin.com / admin

## Notes

This project is a practical reference for building a modular monolith in .NET and is intended for learning, experimentation, and architectural exploration.

## Course Reference

This implementation was inspired by the concepts taught in the Udemy course: [ .NET Backend Bootcamp: Modular Monolith, DDD, CQRS and Outbox ](https://www.udemy.com/course/net-backend-bootcamp-modulith-vsa-ddd-cqrs-and-outbox/?couponCode=KEEPLEARNING).
