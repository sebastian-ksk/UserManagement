
--CREATE TABLE Areas (
--    Id INT PRIMARY KEY IDENTITY(1,1), -- Clave primaria autoincremental
--    AreaName NVARCHAR(100) NOT NULL, -- Nombre del área, obligatorio, longitud máxima 100
--    IsActive BIT NOT NULL DEFAULT 1, -- Activo, valor por defecto: true
--    CreatedDate DATETIME NOT NULL DEFAULT GETDATE() -- Fecha de creación, valor por defecto: fecha actual
--);
--CREATE TABLE Users (
--    Id INT PRIMARY KEY IDENTITY(1,1), -- Clave primaria autoincremental
--    FirstName NVARCHAR(100) NOT NULL, -- Nombre, obligatorio, longitud máxima 100
--    LastName NVARCHAR(100) NOT NULL, -- Apellido, obligatorio, longitud máxima 100
--    Email NVARCHAR(255) NOT NULL, -- Correo electrónico, obligatorio, longitud máxima 255
--    PhoneNumber NVARCHAR(20) NULL, -- Número de teléfono, opcional, longitud máxima 20
--    Address NVARCHAR(500) NULL, -- Dirección, opcional, longitud máxima 500
--    AreaId INT NULL, -- FK hacia Areas
--    IsActive BIT NOT NULL DEFAULT 1, -- Activo, valor por defecto: true
--    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(), -- Fecha de creación, valor por defecto: fecha actual
--    ModifiedDate DATETIME NULL, -- Fecha de modificación, opcional

--    -- Restricción de clave foránea hacia Areas
--    CONSTRAINT FK_Users_Areas FOREIGN KEY (AreaId) REFERENCES Areas(Id) ON DELETE NO ACTION
--);


-- Areas

--INSERT INTO [dbo].[Areas] (AreaName, IsActive, CreatedDate)
--VALUES
--    ('Nómina', 1, GETDATE()),               -- Área de Nómina
--    ('Facturación', 1, GETDATE()),         -- Área de Facturación
--    ('Servicio al Cliente', 1, GETDATE()), -- Área de Servicio al Cliente
--    ('IT', 1, GETDATE()),                  -- Área de Tecnología de la Información
--    ('Recursos Humanos', 1, GETDATE()),    -- Área de Recursos Humanos
--    ('Marketing', 1, GETDATE()),           -- Área de Marketing
--    ('Ventas', 1, GETDATE()),              -- Área de Ventas
--    ('Operaciones', 1, GETDATE()),         -- Área de Operaciones
--    ('Logística', 1, GETDATE()),           -- Área de Logística
--    ('Compras', 1, GETDATE());             -- Área de Compras
