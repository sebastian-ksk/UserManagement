# **Solución UserManagement**
[GITHUB](https://github.com/sebastian-ksk/UserManagement/)

## **Descripción General**
El proyecto **UserManagement** es una solución modular diseñada para gestionar usuarios y áreas asignadas, utilizando una arquitectura basada en capas. Cada capa tiene un propósito específico y está organizada para garantizar la escalabilidad, mantenibilidad y claridad del código.

## **Estructura del Proyecto**
La solución está dividida en varios proyectos, cada uno con una responsabilidad definida:

### **1. UserManagement.WPF**
* Es la interfaz de usuario del proyecto, desarrollada en WPF.
* **Carpetas importantes:**
   * `Views`: Contiene las ventanas y controles principales de la interfaz de usuario, como `MainWindow`, `UserManagementView` y `AreaAssignmentView`.
   * `ViewModels`: Implementa el patrón MVVM para la lógica de la interfaz.
   * `Commands`: Contiene la implementación del patrón `RelayCommand` para manejar comandos.
   * `Converters`: Incluye convertidores de datos, como `BoolToVisibilityConverter`, Este código define un conversor de datos, que se utiliza para convertir valores booleanos a valores de visibilidad en una interfaz de usuario de WPF..
   * `Services`: Define servicios auxiliares como el `DialogService`, para visualización de cuadros de dialogo.

### **2. UserManagement.Core**
* Define la lógica central del negocio.
* **Carpetas importantes:**
   * `Models`: Clases que representan las entidades principales como `User` y `Area`.
   * `Interfaces`: Contiene las interfaces de los servicios y repositorios.
   * `Services`: Implementaciones de servicios como `UserService` y `AreaService`, que contieen la logica de negocio de las vistas.
   * `DTOs`: Objetos de transferencia de datos (Data Transfer Objects) para facilitar la comunicación entre capas.

### **3. UserManagement.Data**
* Administra el acceso a datos utilizando Entity Framework Core.
* **Carpetas importantes:**
   * `Context`: Incluye la configuración del contexto de base de datos (`UserManagementContext`).
   * `Repositories`: Implementaciones de los repositorios para interactuar con la base de datos.
   * `Configuration`: Configuración de la conexión a la base de datos.
   * `Migrations`: Carpeta generada por Entity Framework para manejar las migraciones.

### **4. UserManagement.Common**
* Contiene utilidades y componentes reutilizables.
* **Carpetas importantes:**
   * `Constants`: Define constantes del proyecto, como configuraciones de base de datos.
   * `Exceptions`: Manejo de excepciones personalizadas, `BusinessException`.
   * `Extensions`: Métodos de extensión, `StringExtensions`, para validaciones de formato de campos de entrada.

## **Base de Datos**
El proyecto utiliza SQL Server como base de datos. Existe un proyecto adicional de SQL que incluye los scripts necesarios para crear las tablas y datos iniciales.

### **Tablas principales**
* **Users**: Contiene los datos de los usuarios registrados.
* **Areas**: Contiene las áreas a las cuales se puede asignar un usuario. Un usuario solo puede estar asignado a un área.

## **Scripts Disponibles**
En el proyecto de SQL encontrarás:

1. **Script de creación de tablas**:
   * Crea las tablas `Users` y `Areas`, con las relaciones necesarias.

2. **Script de inserción de datos de prueba**:
   * Inserta datos iniciales en la tabla `Areas` con las áreas predefinidas, como *Nómina, Facturación, Servicio al Cliente, IT, etc*.

## **Primeros pasos**
### **Configuración de la base de datos**
1. Ubica el archivo `UserManagement.WPF\App.config.cs` en el proyecto `UserManagement.WPF`.
2. Configura la cadena de conexión a tu base de datos SQL Server.
3. Ejecuta en base de datos el Script `Create_Tables_And_Insert_Areas/sql` ubicado en el proyecto `UserManagementDB`



## **Características principales**
* **Gestión de usuarios:** Crear, editar y eliminar usuarios desde la interfaz gráfica.
* **Asignación de áreas:** Asignar un área específica a un usuario.
* **Mensajes de error:** Sistema integrado de manejo de errores y retroalimentación visual.
* **Arquitectura MVVM:** Implementación del patrón MVVM para separar la lógica de negocio de la interfaz.

