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
`git clone <your_url_repo>`

`cd <your_repo_name>`

### 2. Run with docker
**Console:**
`docker-compose up --build`

**If the database is not mounted for rebuilding, run the `docker-compose up --build` command again.**

<img width="469" height="784" alt="Снимок экрана 2026-02-24 164101" src="https://github.com/user-attachments/assets/9db73065-99f7-4a95-afd2-35c148405097" />


### 3. Services
- **Gateway:** http://localhost:5000
- **AuthService:** http://localhost:5001
- **CatalogService:** http://localhost:5002
- **CartService:** http://localhost:5003
- **pgAdmin:** http://localhost:5050 
  
## Authentication
Authentication is handled via JWT.
1. Register user via AuthService
2. Obtain JWT token
3. Use token in Authorization: Bearer <token> header
   
**API testing can be done using Postman.**

<img width="1237" height="731" alt="image" src="https://github.com/user-attachments/assets/39c35f7c-a1ab-4fa0-aae6-7b28f09a9534" />

## Service Communication

Internal communication between services is implemented using gRPC over HTTP/2.

gRPC is used for synchronous service-to-service calls to ensure:
- Efficient binary serialization (Protocol Buffers)
- Low latency communication
- Strongly typed contracts between services
