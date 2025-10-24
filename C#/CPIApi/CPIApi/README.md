# 📊 CPI API Service (ASP.NET Core 8 + Caching + JWT + AWS Ready)

A scalable **C# ASP.NET Core RESTful API** that retrieves Consumer Price Index (CPI) data from the **Bureau of Labor Statistics (BLS) public API**, 
caches responses to avoid API rate limits, and supports **JWT-based authentication**.  

The project is containerized via Docker and deployable to AWS (Elastic Beanstalk or ECS).

---

## 🚀 Features

- ✅ Fetches CPI data (value + notes) from the **BLS Public API (V1)**
- ✅ Caches results for **1 day** to reduce external API calls (limit = 25)
- ✅ Implements **JWT authentication & authorization**
- ✅ Provides a **Swagger UI** for testing
- ✅ Containerized with **Docker**
- ✅ Includes **AWS deployment instructions** (Elastic Beanstalk or ECS)
- ✅ Annotated with **time and space complexity**

---

## 🏗️ Architecture Overview

```
Client → CPI API (ASP.NET Core)
        ↳ Cache Layer (In-Memory, 1 day TTL)
        ↳ External Service: BLS API v1 (https://api.bls.gov/publicAPI/v1/)
```

---

## ⚙️ Project Structure

```
CPIApi/
├── Controllers/
│   ├── CpiController.cs        # Handles CPI data requests
│   └── AuthController.cs       # Handles token generation
├── Services/
│   └── CpiService.cs           # Fetches & caches CPI data
├── Utilities/
│   └── JwtTokenService.cs      # JWT generation & validation
├── Models/
│   ├── CpiResponse.cs
│   └── AuthRequest.cs
├── Program.cs                  # ASP.NET Core entry point
├── appsettings.json            # Config (JWT, URLs, etc.)
└── Dockerfile                  # Container definition
```

---

## 🧠 Design Decisions & Assumptions

1. **Caching Strategy**:  
   Uses in-memory cache (`IMemoryCache`) with 1-day expiration to avoid exceeding BLS rate limits (25 calls per day per IP).

2. **API Structure**:  
   - `GET /api/cpi?year=2020&month=5` → Returns `{ cpiValue: 257, notes: "..." }`
   - `POST /api/auth/token` → Returns JWT token (for Swagger or clients)

3. **Authentication**:  
   JWT (HS256) using symmetric key stored in environment variable or appsettings.

4. **Error Handling**:  
   Graceful fallback for API/network errors with `500` response.

5. **Environment Variables**:  
   - `Jwt__Key` – JWT secret key (≥ 16 chars)
   - `ASPNETCORE_ENVIRONMENT` – Environment setting (Development/Production)

---

## 🧪 Running Locally

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code
- Optional: [Docker Desktop](https://www.docker.com/)

### Run via .NET CLI
```bash
dotnet build
dotnet run
```
Visit Swagger:  
👉 https://localhost:5001/swagger

---

## 🔐 Authentication Flow

1. **Get Token**
   ```
   POST /api/auth/token
   {
     "username": "testuser",
     "password": "password"
   }
   ```
   → Response: `{ "token": "eyJhbGciOi..." }`

2. **Authorize in Swagger**
   - Click **"Authorize"** button
   - Paste the token (without "Bearer ")

3. **Call Protected API**
   ```
   GET /api/cpi?year=2020&month=5
   ```

---

## 🐳 Running via Docker

### Build
```bash
docker build -t cpiapi .
```

### Run
```bash
docker run -p 8080:8080 -e Jwt__Key="this_is_a_long_secret_key_1234567890!!" cpiapi
```

Visit:  
👉 http://localhost:8080/swagger

---

## ☁️ Deploying to AWS

### Option 1 – Elastic Beanstalk (simplest)
1. Run:
   ```bash
   dotnet publish -c Release -o ./publish
   ```
2. Zip contents of `publish/` folder.
3. Upload to **Elastic Beanstalk → Create Application** (Platform: .NET 8)
4. Add Environment Variables:
   - `Jwt__Key`: <your-secret-key>
   - `ASPNETCORE_ENVIRONMENT`: Production
5. Access:
   ```
   https://yourapp-env.us-west-2.elasticbeanstalk.com/swagger
   ```

### Option 2 – ECS (Docker)
1. Build and push Docker image to ECR:
   ```bash
   aws ecr create-repository --repository-name cpiapi
   aws ecr get-login-password --region us-west-2 | docker login --username AWS --password-stdin <aws-account-id>.dkr.ecr.us-west-2.amazonaws.com
   docker tag cpiapi:latest <aws-account-id>.dkr.ecr.us-west-2.amazonaws.com/cpiapi:latest
   docker push <aws-account-id>.dkr.ecr.us-west-2.amazonaws.com/cpiapi:latest
   ```
2. Create ECS Fargate service (via AWS Console or Copilot CLI):
   ```bash
   copilot init
   ```
3. AWS handles scaling, load balancing, and service routing automatically.

---

## 📈 Complexity Analysis

| Operation | Time Complexity | Space Complexity |
|------------|----------------|------------------|
| Fetch CPI (with cache) | O(1) average | O(N) for cached month-year pairs |
| Cache lookup | O(1) | O(N) |
| JWT generation | O(1) | O(1) |

---

## 📜 API Example

**Request:**
```
GET /api/cpi?year=2020&month=08
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2...
```

**Response:**
```json
{
  "value": 17649,
  "notes": "Preliminary"
}
```

---

## 🧩 Tools & Frameworks

- **.NET 8** – Core framework
- **ASP.NET Core Web API**
- **IMemoryCache** – Local caching
- **System.IdentityModel.Tokens.Jwt** – JWT auth
- **Swashbuckle** – Swagger/OpenAPI
- **Docker** – Containerization
- **AWS Elastic Beanstalk / ECS** – Deployment

---

## 👨‍💻 Author

**Michael Lee**  
C# / .NET Developer | Cloud Engineer  
📧 _miclee2007@hotmail.com_  
📍 Bellevue, WA, USA 98007  

---

## 🏁 License

This project is licensed under the MIT License.  
You are free to use, modify, and distribute it with attribution.

---

> “Cache smart, scale infinitely.” 💡  
> Designed for reliability, efficiency, and easy cloud deployment.
