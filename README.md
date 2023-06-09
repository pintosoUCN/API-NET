# Practica Backend

Este proyecto es un ejemplo de una aplicación .NET que utiliza una base de datos SQL Server y proporciona una API para administrar usuarios, libros y reservas.

## Requisitos previos

- [.NET Core SDK](https://dotnet.microsoft.com/download) instalado en tu máquina.
- Un servidor de base de datos SQL Server disponible.

## Pasos para ejecutar el proyecto

1. **Clonar el repositorio desde GitHub:**
git clone https://github.com/pintosoUCN/API-NET.git

2. **Crear las tablas en SQL Server.** Utilizar el siguiente código SQL:

-- Crear tabla Users

CREATE TABLE [Users]
(
    id INT PRIMARY KEY,
    code VARCHAR(50),
    name VARCHAR(100),
    faculty VARCHAR(100)
);

-- Crear tabla Books

CREATE TABLE Books
(
    id INT PRIMARY KEY,
    code VARCHAR(50),
    book VARCHAR(100),
    description VARCHAR(500)
);

-- Crear tabla Reserves

CREATE TABLE Reserves
(
    id INT PRIMARY KEY IDENTITY(1,1),
    code VARCHAR(50),
    user_id INT,
    book_id INT,
    reserved_at DATETIME,
    FOREIGN KEY (user_id) REFERENCES [Users](id),
    FOREIGN KEY (book_id) REFERENCES Books(id)
);

3. **Agregar datos a las tablas en SQL Server.** Utilizar el siguiente código SQL:

-- Insertar datos en la tabla User

INSERT INTO [Users] (id, code, name, faculty)
VALUES (1, 'U001', 'John Doe', 'Computer Science');

INSERT INTO [Users] (id, code, name, faculty)
VALUES (2, 'U002', 'Jane Smith', 'Business');

-- Insertar datos en la tabla Book

INSERT INTO Books (id, code, book, description)
VALUES (1, 'B001', 'Introduction to Programming', 'A beginners guide to programming');

INSERT INTO Books (id, code, book, description)
VALUES (2, 'B002', 'Data Structures and Algorithms', 'A comprehensive guide to data structures and algorithms');

-- Insertar datos en la tabla Reserve

INSERT INTO Reserves (code, user_id, book_id, reserved_at)
VALUES ('R001', 1, 1, '2023-06-01 10:00:00');

INSERT INTO Reserves (code, user_id, book_id, reserved_at)
VALUES ('R002', 1, 2, '2023-06-03 14:30:00');

INSERT INTO Reserves (code, user_id, book_id, reserved_at)
VALUES ('R003', 2, 1, '2023-06-05 09:15:00');

4. **Actualizar la conexión a la base de datos en el archivo appsettings.json** Cambiar los atributos "Server" y "Database"

5. **Si es necesario reataurar las dependencias y compilar el proyecto** Debes ejecutar en el terminal:
dotnet restore
dornet build

6. **Para iniciar el proyecto** Ejecutar en el terminal:
dotnet run

7. **Abrir navegador web** visitar la URL http://localhost:5045/swagger/index.html


¡Listo! Ahora puedes explorar y probar la API en tu entorno local.
