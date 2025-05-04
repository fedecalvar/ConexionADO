Comandos para la base de datos sql

CREATE DATABASE Comercio;
USE Comercio;
CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50)
);

CREATE TABLE Productos (
    Codigo INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(255),
    Precio DECIMAL(10,2),
    Stock INT,
    CategoriaId INT,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);

-- Insertar categorías
INSERT INTO Categorias (Nombre) VALUES ('Tecnología'), ('Hogar'), ('Ropa');

-- Insertar productos
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategoriaId) VALUES
('Notebook Lenovo', 'Notebook i5 8GB RAM', 850000, 10, 1),
('Licuadora Philips', '600W, vaso de vidrio', 320000, 5, 2),
('Camisa Blanca', 'Manga larga, algodón', 180000, 15, 3);

CREATE TABLE Contactos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Telefono VARCHAR(20),
    Correo VARCHAR(100),
    Categoria VARCHAR(50)
);

INSERT INTO Contactos (Nombre, Apellido, Telefono, Correo, Categoria)
VALUES ('Juan', 'Pérez', '3512345678', 'juan.perez@mail.com', 'Amigo');
