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

============================================================
DEPLOYING .NET BACKEND & TESTS ON AWS (WINDOWS HOSTING)
============================================================

Option: Deploy to AWS EC2 with Windows Server & IIS
------------------------------------------------------------

1. **Launch a Windows EC2 Instance**:
   - Choose AMI: *Microsoft Windows Server with IIS installed*
   - Ensure ports 80 (HTTP) and 443 (HTTPS) are open in security group

2. **Remote Desktop (RDP) into the Instance**:
   - Download & install [.NET 7 Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
   - Use RDP or WinSCP to upload your backend app

3. **Publish Your App Locally**:
   ```bash
   dotnet publish -c Release -r win-x64 -o ./publish
   ```

4. **Copy Published App to IIS Directory on Server**:
   - Path: `C:\inetpub\wwwroot\MyApp`

5. **Configure IIS**:
   - Open IIS Manager
   - Add a new Website → Point to `MyApp` folder
   - Use Application Pool → No Managed Code
   - Bind to HTTP or HTTPS ports

6. **Set Environment Variables (Optional)**:
   - Windows → System Properties → Environment Variables
   - Add keys such as:
     - `ConnectionStrings__DefaultConnection`
     - `JWT__Key`

7. **Restart IIS**:
   ```powershell
   iisreset
   ```

8. **Test**
   - Open browser with public EC2 DNS/IP → App should be running

------------------------------------------------------------
Running Unit Tests on AWS CodeBuild (Optional CI/CD)
------------------------------------------------------------
1. **Create buildspec.yml**:
   ```yaml
   version: 0.2
   phases:
     install:
       runtime-versions:
         dotnet: 7.0
     build:
       commands:
         - dotnet test
   ```
2. **Push to CodeCommit or GitHub**
3. **Set up AWS CodeBuild project** to pull the repo and run the tests
