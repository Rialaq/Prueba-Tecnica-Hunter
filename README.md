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

#### Patron Repository.

## 🔑 Probar endpoins con jwt: 
1. Crear usuario con el endpoint "api/user/create/"
   <img width="1071" alt="image" src="https://github.com/Rialaq/Prueba-Tecnica-Hunter/assets/51594905/69b99d23-f963-403b-b93c-fb98613e8747">

3. Usar usuario creado en el enpoint "api/user/login"
      <img width="1077" alt="image" src="https://github.com/Rialaq/Prueba-Tecnica-Hunter/assets/51594905/63ddf6da-28e3-43cc-9313-517350de349a">

5. Copiar el token retornado y colocar en Authorize dentro de Swagger.
   <img width="1133" alt="image" src="https://github.com/Rialaq/Prueba-Tecnica-Hunter/assets/51594905/7059cb69-9982-4a12-9e0f-ccebd12f49f6">
   <br>
   <img width="494" alt="image" src="https://github.com/Rialaq/Prueba-Tecnica-Hunter/assets/51594905/5b177f3b-63de-4476-90bc-21ca1f6d42d5">


    
