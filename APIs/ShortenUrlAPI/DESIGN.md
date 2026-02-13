# ShortenUrlAPI - Design Document

## Overview
A lightweight URL shortening service implemented as an ASP.NET Core Web API targeting .NET 8/10. The service accepts long URLs and returns a short alias. It supports custom aliases, optional TTLs, basic analytics (click counts), and safe redirects. The service is designed to be horizontally scalable and to provide low-latency lookups.

## Goals
- Shorten any valid URL and return a compact alias.
- Redirect short aliases to original URLs with low latency.
- Prevent collisions and allow optional custom aliases.
- Provide basic analytics: click count, creation date, expiry.
- Secure endpoints and rate-limit abuse.

## Non-goals
- Full-featured enterprise analytics pipeline.
- Complex user management or OAuth (support via future extension).

## High-level Architecture
- API Tier: ASP.NET Core Minimal API / Controllers
- Storage:
  - Primary store: PostgreSQL (or any relational DB) for persistent mapping
  - Cache: Redis for hot short-code lookup and TTL expiration
- Background worker: optional cleanup and analytics aggregation
- Optional CDN / edge caching for redirects

## Data Model
ShortUrl table (Postgres)
- `id` (bigserial) — internal PK
- `alias` (varchar, unique) — short code (e.g. `abc123`)
- `destination` (text) — original long URL
- `created_at` (timestamp)
- `expires_at` (timestamp, nullable)
- `owner_id` (nullable) — optional user id
- `click_count` (bigint) — optional, can be updated in DB or aggregated
- `is_active` (bool)

Analytics (optional)
- `id`, `shorturl_id`, `timestamp`, `ip`, `user_agent`, `referrer` — stored to event store or K/V for later aggregation

## Alias generation
- Use incremental numeric `id` encoded in Base62 to produce compact aliases.
  - Pros: deterministic, collision-free, short and increasing length.
  - Implementation: insert row to get `id` then convert to Base62 string; write alias back via update or compute before insert if using sequences.
- For custom alias: validate uniqueness and allowed charset (A-Z a-z 0-9 `-` `_`), length limits.
- Optional deterministic hash (SHA256 -> Base62) if avoiding DB insert-first design, but collisions must be handled.

## APIs
Base URL: `POST /api/v1/shorten`
- Request:
  - `destination` (string, required)
  - `customAlias` (string, optional)
  - `expiresInSeconds` (int, optional)
  - `ownerId` (string, optional)
- Response: 201 Created
  - `{ "alias": "abc123", "shortUrl": "https://short.example/abc123", "expiresAt": "2026-01-01T00:00:00Z" }
`

Redirect:
- `GET /{alias}` -> 301 Redirect to `destination` if active and not expired.
- If expired -> return 410 Gone or 404 depending on policy.

Lookup / Metadata:
- `GET /api/v1/short/{alias}` -> returns JSON metadata: `destination`, `createdAt`, `expiresAt`, `clickCount`.

Delete / deactivate (owner only):
- `DELETE /api/v1/short/{alias}` -> 204 No Content

Analytics:
- `GET /api/v1/short/{alias}/stats` -> restricted to owner or admin

## Rate limiting & Abuse prevention
- Rate-limit create endpoint per IP and per owner (e.g., 100/day by default).
- Validate `destination` to prevent internal network SSRF (allowlist/denylist).
- CAPTCHA or auth for bulk creations.

## Security
- Validate input URL: scheme (http/https), host normalization, max length.
- Store `destination` as text and ensure safe redirect (no open-redirect chaining). Use `Rel= noopener` on UI links.
- Protect management endpoints via API keys / JWT.
- Use HTTPS.

## Performance & Scalability
- Use Redis cache for alias -> destination mapping. On redirect, check Redis first; fallback to DB and populate cache.
- Cache keys expire at `expiresAt` if set.
- Partition DB if scale requires; use sequences for ID generation.
- Use connection pooling and prepared statements.

## Collision handling
- For Base62 id approach, collisions don't occur.
- For hash-based alias, on collision attempt append incremental salt or fallback to sequence-based alias.

## Consistency
- Write-through strategy for cache: after creating mapping in DB, set Redis key.
- For click counts: increment in Redis and periodically persist aggregated counts to DB (avoid DB hot-writes on every redirect).

## Failure cases & retry
- If cache set fails, system still functions via DB lookup.
- If DB insert fails due to unique constraint (rare for custom alias), return 409 Conflict.

## Deployment
- Docker images for API and worker.
- Use managed Postgres and Redis in production.
- K8s deployment with autoscaling.

## Project structure (suggested)
- `ShortenUrlAPI/` (project root)
  - `Program.cs` (minimal API or host)
  - `Controllers/` or `Endpoints/` (create, lookup, stats)
  - `Services/` (`IAliasGenerator`, `IRepository`, `ICacheService`, `IAnalyticsService`)
  - `Data/` (EF Core `DbContext`, migrations)
  - `DTOs/` (requests/responses)
  - `Workers/` (analytics persistence)

## Technology choices
- ASP.NET Core (.NET 8/10)
- EF Core + Npgsql for Postgres
- Redis for hot cache
- Docker + Kubernetes

## Example sequence (create & redirect)
1. Client POST `/api/v1/shorten` with `destination`.
2. API validates input, inserts record, obtains `id`, converts to Base62 `alias`.
3. API updates record with alias (or writes alias field if precomputed) and sets Redis cache.
4. Client receives short URL.
5. User requests `GET /{alias}` — API checks Redis -> redirect (increment click counter in Redis asynchronously).

## Open questions
- Multi-tenant requirements? per-user quotas?
- Custom domain support?
- GDPR/log retention policy for analytics?

## Next steps
1. Create `ShortenUrlAPI` project skeleton (ASP.NET Core minimal API) with endpoints.
2. Implement `IAliasGenerator` using sequence-to-Base62 approach.
3. Implement `IRepository` backed by EF Core migrations and Postgres models.
4. Add Redis cache integration and background worker for analytics aggregation.
5. Add unit/integration tests, rate limiting, and monitoring/alerts.


---

Created path: `APIs/ShortenUrlAPI/DESIGN.md`
