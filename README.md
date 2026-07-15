# Trion

Trion is a triathlon coaching platform. Coaches manage their athletes and build structured
training plans; athletes follow the sessions those plans lay out and log the activities they
complete. The goal is to give coaches one place to plan training across swim, bike, and run
disciplines, and to give athletes a clear view of what to do and what they've done.

## Domain model

The core domain (`Trion.Domain`) is built around five aggregates:

- **Coach** — the person authoring training plans for their athletes.
- **Athlete** — the person following a coach's training plan.
- **Plan** — a training plan, made up of **Blocks** (e.g. training phases or weeks).
- **Session** — a single planned workout, made up of **Steps** (e.g. warm-up, intervals, cool-down).
- **Activity** — a completed piece of training logged against a session.

## Tech stack

**Backend** — `backend/`
- .NET 10 / ASP.NET Core Web API
- CQRS via [MediatR](https://github.com/jbogard/MediatR), with [ErrorOr](https://github.com/amantinband/error-or) for
  railway-oriented error handling instead of exceptions
- EF Core with PostgreSQL for persistence
- [Scalar](https://github.com/scalar/scalar) for interactive OpenAPI docs in Development
- [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/) for local orchestration (Postgres,
  the API, and the frontend, run together from one entry point), plus OpenTelemetry, health
  checks, and service discovery via a shared `Trion.ServiceDefaults` project

**Frontend** — `frontend/`
- React 19 + TypeScript
- Vite

## Architecture

The backend follows Clean Architecture, with dependencies pointing inward:

```
Trion.WebApi            ASP.NET Core controllers, composition root
  → Trion.Application    CQRS commands/queries, MediatR handlers
  → Trion.Infrastructure EF Core, repositories, ApplicationDbContext
  → Trion.Domain         Aggregates, entities, domain logic (no dependencies)
  → Trion.Contracts      Request/response DTOs shared with API consumers
```

`Trion.Infrastructure` depends on `Trion.Application` and `Trion.Domain`; `Trion.Application`
depends only on `Trion.Domain`; `Trion.Contracts` and `Trion.Domain` have no internal
dependencies of their own.

Solution layout (`backend/trion.slnx`):

```
backend/
  src/
    Trion.AppHost/           Aspire orchestrator — Postgres, WebApi, and the frontend
    Trion.ServiceDefaults/   Shared OpenTelemetry/health-check/resilience wiring
    Trion.Domain/            Coach, Athlete, Plan, Session, Activity aggregates
    Trion.Application/       Commands/queries per feature (Athletes, Coaches)
    Trion.Contracts/         Shared request/response DTOs
    Trion.Infrastructure/    EF Core DbContext, repositories, migrations
    Trion.WebApi/            Controllers, Program.cs, appsettings
  test/
    Trion.Domain.UnitTests/  xUnit tests for the Domain layer
frontend/
  src/                       React + TypeScript app (Vite)
```

## Getting started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (for the frontend)
- A container runtime (Docker Desktop, Podman, etc.) — Aspire runs Postgres as a container

### Run everything via Aspire (recommended)

```bash
cd backend/src/Trion.AppHost
dotnet run
```

This starts Postgres, `Trion.WebApi`, and the Vite frontend together, opens the Aspire
dashboard, applies EF Core migrations automatically, and injects the frontend's
`VITE_API_BASE_URL` so it can reach the API without any manual configuration.

### Running the backend standalone

If you're not using the AppHost, `Trion.WebApi` still needs a Postgres connection string,
supplied via user secrets rather than `appsettings.json`:

```bash
cd backend/src/Trion.WebApi
dotnet user-secrets set "ConnectionStrings:triondb" "Host=localhost;Port=5432;Database=triondb;Username=postgres;Password=postgres"
dotnet run
```

The API listens on `http://localhost:5119` (and `https://localhost:7241`). In Development,
Scalar's interactive API docs are also mapped — check the startup console output for the
exact URL.

### Running the frontend standalone

```bash
cd frontend
npm install
npm run dev
```

Note: without the AppHost, `VITE_API_BASE_URL` won't be set, so the frontend won't be able
to reach the API unless you configure that yourself.

### Tests

```bash
cd backend
dotnet test
```

## Current status

Full CQRS command/query handlers, repositories, and REST endpoints exist today for
**Coaches** and **Athletes** (`/api/coaches`, `/api/athletes`). **Plan**, **Session**, and
**Activity** are modeled in the domain layer with unit test coverage, but don't yet have
application-layer handlers, persistence, or API endpoints — that's the next slice of work.
The frontend is still mostly a fresh scaffold; it currently only proves connectivity to the
API (a status line confirming it can reach `/api/coaches`), with no real UI built yet.
