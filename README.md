# Prueba Tecnica Hunter
Prueba tecnica para solicitud de empleo Desarollador Back-end, 
se solicito una WebApi para Peliculas y Actores.

- Fecha de Entrega: 18/11/23 12:00pm

## 💻 Tecnologias.
1) .Net Core 6
2) EF Core 5
3) Swagger
4) JWT
5) SQL Server

## 🛠 Arquitectura y Patrones.
#### Arquitectura basada en Onion (Clean Architecture)
##### Capas
1. Dominio.
   - Models
3. Aplicacion.
   - IServices
   - Services
5. Infraestructura.
   - Migrations
   - Context
   - IRepository
   - Repository
7. Presentacion.
   - Controller
   - ErrorHandlingMiddleware
   - JWT Config

Patron Repository.
