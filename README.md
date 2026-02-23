# Shop Microsevice


Microservices-based backend application built with ASP.NET Core.

The project demonstrates a distributed architecture using:
- gRPC for inter-service communication
- YARP API Gateway
- PostgreSQL
- Redis
- Docker Compose
- JWT authentication


## Architecture:

<img width="693" height="463" alt="image" src="https://github.com/user-attachments/assets/1b248ae2-1195-413d-9bd4-8b8b0b89fb43" />

The system consists of the following services:
- **AuthService** – User registration, authentication, JWT issuing
- **CatalogService** – Product management
- **CartService** – Shopping cart (Redis-based)
- **Gateway** – API Gateway (YARP) for routing external requests


## Tech Stack
- ASP.NET Core
- gRPC
- YARP Reverse Proxy
- Entity Framework Core
- PostgreSQL
- Redis
- Docker & Docker Compose
- JWT Authentication


## Getting Started
### 1. Clone repository
**Console:**
git clone <your_url_repo>

cd <your_repo_name>

### 2. Run with docker
**Console:**
docker-compose up --build or docker compose up --build

### 3. Services
- **Gateway:** http://localhost:50050
- **AuthService:** http://localhost:5001
- **CatalogService:** http://localhost:5002
- **CartService:** http://localhost:5003

## Authentication
Authentication is handled via JWT.
1. Register user via AuthService
2. Obtain JWT token
3. Use token in Authorization: Bearer <token> header
   
**API testing can be done using Postman.**
