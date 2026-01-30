-- Initialize additional database and user required by docker-compose
-- Creates database `apinum10db` and user `postgres_apinum10` with password `ApiNumber10M`
-- Grants all privileges on the new database to the new user

CREATE USER postgres_apinum10 WITH PASSWORD 'ApiNumber10M';
CREATE DATABASE apinum10db OWNER postgres_apinum10;
GRANT ALL PRIVILEGES ON DATABASE apinum10db TO postgres_apinum10;
