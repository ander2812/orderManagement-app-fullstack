# Order Management - Aplicación Fullstack

## Información para construir y ejecutar el proyecto

- El backend corre en **https** en el puerto **5001**.
- El frontend corre en el puerto **7200**.
- La aplicación usa una base de datos SQL Server local.
- El script que crea y pobla la base de datos y las tablas, se encuentra en el repositorio en un archivo llamado `Script DB`
- La configuración de la conexión a la base de datos se encuentra en el archivo `appsettings.json` dentro de la carpeta `OrderManagement.Api`.
- Se ignoró la carpeta `node_modules` para mantener el repositorio limpio, por lo que es necesario ejecutar `npm install` en la carpeta del frontend para instalar las dependencias.

### Pasos para ejecutar la aplicación

1. Clonar el repositorio.
2. Configurar la cadena de conexión a la base de datos en el archivo `OrderManagement.Api/appsettings.json` según tu entorno local.
3. En la carpeta del backend (`OrderManagement.Api`), restaurar paquetes y correr la API.
4. En la carpeta del frontend, ejecutar `npm install` para instalar dependencias.
5. Ejecutar el frontend con `npm start` o el comando que uses para levantar la aplicación Angular.
6. Asegurarse que el backend esté corriendo en https://localhost:5001 y el frontend en http://localhost:7200.

## Pasos para probar la aplicación

1. La aplicación usa JWT para la autenticación, por lo cual es necesario ingresar con cualquiera de los siguientes usuarios:
   
Customer: `User Name:` mike.ray `Password:`Client123!

SalesManager: `User Name:`judy.manager `Password:`Manager123!

2. Los usuarios tienen visuales distintas dependiendo del rol, Customer solo puede ver un listado con las ordenes que le corresponden. Por otro el rol SalesManager, puede ver a todos los clientes con su respectivas ordenes, también puede realizar creaciones de nuevas ordenes.
   Nota: Por tiempo no se alcanzó a realizar el CRUD completo desde la interface del front.

---

## Información relevante sobre la prueba técnica

- La aplicación no está 100% terminada por limitaciones de tiempo.
- La arquitectura usada es una híbrida inspirada en Clean Architecture y principios SOLID, no es una implementación estricta debido al tiempo disponible.

---

## Explicación de cómo se ejecutó la prueba

- Se diseñó y desarrolló un backend en .NET Core con API REST, consumida por un frontend en Angular.
- Se trabajó con SQL Server local para la persistencia.
- Se implementaron funcionalidades clave para mostrar conocimiento en arquitectura, patrones y buenas prácticas.
- La intención es ampliar la aplicación si se dispone de más tiempo.
