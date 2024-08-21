# Gracias por tu interés en Sonata Musical! 🎸
# Sonata Musical 🎶

Bienvenido al proyecto **Sonata Musical**, una aplicación de landing page para la venta de instrumentos musicales.

## Descripción del Proyecto

**Sonata Musical** es una plataforma para comprar y vender instrumentos musicales. Este proyecto utiliza las siguientes tecnologías:

- **Backend:** 
  - 🛠️ **C#** con **Entity Framework Core** para la gestión de datos.
  - 💾 **MySQL** como sistema de gestión de bases de datos.
  - 🔒 **JWT** para autenticación y autorización.

- **Frontend:**
  - 🌐 **Angular CLI** para construir la interfaz de usuario.

- **ORM:**
  - 📦 **Sequelize** para la gestión de la base de datos en el frontend.

## Funcionalidades

- **Usuarios:** Registro y autenticación con asignación automática de roles.
- **Productos:** Gestión de productos (alta, baja, modificación).
- **Carrito:** Funcionalidad para añadir productos al carrito.
- **Pasarela de Pagos:** Integración para realizar pagos en línea.
- **Dashboard:**
  - 🛠️ **Administrador:** Panel para la gestión de productos y roles.
  - 👤 **Usuario:** Panel para visualizar y gestionar el carrito.

## Estructura de la Base de Datos

La base de datos (puedes llamarla como quieras)  en mi caso se llama **sonataMusical** incluye las siguientes tablas:

- **Products:** 
  - `id` (Autoincremental)
  - `name`
  - `description`
  - `stock`
  - `price`
  - `fechaDeCreacion`
  - `fechaDeBaja`

- **Users:** 
  - `id` (Autoincremental)
  - `name`
  - `lastName`
  - `telefono`
  - `email`
  - `password`
  - `roleId` (Relación con la tabla Roles)

- **Roles:** 
  - `id`
  - `description` (Valores: `Admin` = 1, `User` = 2)

## Cómo Empezar

1. **Clonar el repositorio:**
   ```bash
   git clone https://github.com/tu-usuario/sonata-musical.git
