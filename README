🧾 PagosCQRSDDD - Documentación del Proyecto 📌 Descripción General PagosCQRSDDD es una solución desarrollada en .NET que implementa los patrones CQRS (Command Query Responsibility Segregation) y DDD (Domain-Driven Design) para la gestión de pagos. Su objetivo es demostrar una arquitectura limpia y escalable para sistemas transaccionales modernos, desacoplando las operaciones de lectura y escritura.

🏗️ Arquitectura del Proyecto El proyecto sigue una estructura por capas basada en DDD:

Domain: Define las entidades, objetos de valor, agregados y lógica de dominio.

Application: Contiene la lógica de aplicación, comandos, queries y handlers.

Infrastructure: Implementa la persistencia (SQL Server y MongoDB), acceso a datos y servicios externos.

API: Exposición de endpoints HTTP a través de ASP.NET Core.

📂 Estructura de Carpetas

PagosCQRSDDD
Pagos.Domain
Entidades, Agregados, Reglas de Negocio
Pagos.Application
Comandos, Queries, Handlers, Interfaces
Pagos.Infrastructure
Repositorios SQL y MongoDB, Configuraciones
Pagos.API
Controladores, Configuraciones, Program.cs
📦 Tecnologías Utilizadas

.NET 8
C#
Entity Framework Core (para SQL Server)
MongoDB (para proyecciones de lectura)
MediatR (para manejo de CQRS)
AutoMapper
ASP.NET Core Web API
🧪 Ejecución Local Clona el repositorio:

git clone https://github.com/warlospp/PagosCQRSDDD.git Configura el archivo appsettings.json con tus cadenas de conexión para SQL Server y MongoDB.

Ejecuta las migraciones (si usas SQL Server):

dotnet ef database update --project Pagos.Infrastructure Inicia el proyecto:

dotnet run --project Pagos.API 🔄 Operaciones Implementadas 📥 Comandos (Commands) CrearPagoCommand

ActualizarPagoCommand

EliminarPagoCommand

📤 Consultas (Queries) ObtenerPagoPorIdQuery (MongoDB)

ObtenerTodosLosPagosQuery

🧩 Integración con MongoDB MongoDB se usa como fuente de lectura (read model) para desacoplar las operaciones de consulta. Las proyecciones se generan al crear un nuevo pago exitosamente.

Configuración en appsettings.json:

"MongoDbSettings": { "ConnectionString": "mongodb+srv://user:password@cluster.mongodb.net/?retryWrites=true", "DatabaseName": "bddprodserv", "CollectionName": "Pagos" } 📚 Ejemplo de Uso Crear un Pago (POST /api/pagos) { "clienteId": 1, "monto": 150.00, "fecha": "2025-05-06T00:00:00" } Consultar un Pago por ID (GET /api/pagos/{id}) Devuelve el documento desde MongoDB.

✅ Pendientes y Futuras Mejoras Autenticación y autorización.

Manejo de eventos (event sourcing o integración con message bus).

Soporte a pagos recurrentes.

Tests unitarios y de integración.

👨‍💻 Contribuciones ¡Bienvenidos los PRs! Por favor asegúrate de seguir las convenciones de codificación del proyecto y ejecutar pruebas antes de contribuir.

📄 Licencia MIT License