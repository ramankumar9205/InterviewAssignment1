# InterviewAssignment1
============================================================
BACKEND (.NET CORE) DOCUMENTATION
============================================================

OVERVIEW:
This backend, developed in ASP.NET Core 7.0, is responsible for user authentication, role-based user management, document CRUD operations, and ingestion process control. It uses JWT-based authentication and integrates with Identity Framework and PostgreSQL.

TECHNOLOGIES USED:
- ASP.NET Core 7.0
- Entity Framework Core
- PostgreSQL
- ASP.NET Core Identity
- JWT Authentication
- Swagger (OpenAPI)

============================================================
API ENDPOINTS
============================================================

1. AUTHENTICATION API (api/auth)
------------------------------------------------------------
- POST /api/auth/login
  → Logs in a user and returns a JWT token.
  Request Body: { "email": string, "password": string }
  Response: { token: string }

2. USER MANAGEMENT (Admin only)
------------------------------------------------------------
- POST /api/users: Create a new user.
- GET /api/users: Retrieve all users.
- PUT /api/users/{id}/roles: Update user roles.

3. DOCUMENT MANAGEMENT
------------------------------------------------------------
- GET /api/documents: List all documents.
- POST /api/documents: Upload a new document.
- PUT /api/documents/{id}: Update a document.
- DELETE /api/documents/{id}: Delete a document.

4. INGESTION CONTROL
------------------------------------------------------------
- POST /api/ingestion/trigger/{documentId}: Trigger ingestion.
- GET /api/ingestion/status/{documentId}: Check ingestion status.
- DELETE /api/ingestion/cancel/{documentId}: Cancel ingestion.

============================================================
UNIT TESTING (.NET BACKEND)
============================================================

TESTING FRAMEWORKS:
- xUnit: Unit testing framework for .NET Core
- Moq: Mocking library for dependency injection in tests

SAMPLE TEST CASE: Login
------------------------------------------------------------
Test: Validate successful login with valid credentials.
- Mocks UserManager & SignInManager using Moq
- Tests AuthController.Login() method
- Asserts response is 200 OK with a valid token
