# Proyecto Ropa

Este proyecto es una API que permite llevar el control de ventas y compras de prendas.

## Características de la API

- **Registro de usuarios:** Permite a los usuarios crear cuentas en la plataforma.
- **Autenticación con usuario y contraseña:** Facilita la entrada segura a la plataforma a través de credenciales.
- **Generación y utilización del token:** Genera tokens de autenticación que son utilizados para verificar la identidad del usuario.
- **CRUD completo para cada entidad:** Proporciona operaciones completas de Crear, Leer, Actualizar y Borrar para todas las entidades del sistema.

## Uso

Una vez se haya realizado la actualización de la base de datos utilizando el comando:

```bash
dotnet ef database update
```
En la carpeta API, deberá registrar los roles "Admin" y "Employee" en la tabla de Roles. A continuación, deberá registrar un usuario y asignarle el rol de "Admin" o "Empleado".

## Generación del token 

- **Endpoint**: `http://localhost:5181/api/User/token`
- **Método**: `POST`
- **Payload**:
  ```json
  {
    "Nombre": "username",
    "Contraseña": "userpassword"
  }
    ```
## Desarrollo de los Endpoints requeridos

Todos los endpoints cuentan con paginación y requieren un token de tipo "Employee" o "Admin" para su uso. Todos los parámetros necesarios se pasan a través de la URL, y se pueden visualizar en Swagger.

### 1. Listar los insumos que pertenecen a una prenda específica

- **Endpoint**: `http://localhost:5181/api/Insumo/GetInsumoByPrendas`

### 2. Listar los insumos que son vendidos por un determinado proveedor cuya entidad sea Persona Jurídica

- **Endpoint**: `http://localhost:5181/api/Insumo/GetInsumosByProveedorJuridico`

### 3. Listar todas las órdenes de producción cuyo estado sea "En Proceso"

- **Endpoint**: `http://localhost:5181/api/Orden/GetOrdenesByEstadoProceso`

### 4. Listar los empleados por un cargo específico

- **Endpoint**: `http://localhost:5181/api/Empleado/GetEmpleadosByCargo`

### 5. Listar las órdenes de producción que pertenecen a un cliente específico

- **Endpoint**: `http://localhost:5181/api/Orden/GetOrdenesByCliente`

### 6. Listar las ventas realizadas por un empleado específico

- **Endpoint**: `http://localhost:5181/api/Venta/GetVentasByEmpleado`

### 7. Listar los productos y tallas del inventario

- **Endpoint**: `http://localhost:5181/api/InventarioTalla`