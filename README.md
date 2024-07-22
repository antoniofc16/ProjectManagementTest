# Proyecto: ProjectManagementTest

Esta solucion esta configurada para iniciar 2 proyectos al mismo tiempo, un proyecto de Servicios Web y otro de Cliente web que consumira el primero.

## Configuracion de Entorno

Esta solucion usa un archivo secrets.json para almacenar valores privados, este archivo se puede crear dando doble click a Connected Services o Servicios Conectados.

![image](https://github.com/user-attachments/assets/38536d9e-6c72-4bc7-8f05-101ad671b36c)

Luego damos click al icono de cruz verde (agregar nueva dependencia de servicio) y seleccionamos la opcion "Secrets.json (local)". Hacemos esto en los 2 proyectos y pegamos el contenido de los secrets.json de abajo en los respectivos proyectos. 

![image](https://github.com/user-attachments/assets/41cd2bfa-3d51-4f46-848b-7fd9ea4c821f)


### secrets.json (Web Client)
```JSON
{
  "ApiUrl": "https://localhost:7205/api",
  "Jwt:Key": "41ACA650-21E8-409E-A3D5-95C3A1AAAB04",
  "Jwt:Issuer": "https://localhost:7247, http://localhost:5124, https://localhost:7205, http://localhost:5259",
  "Jwt:Audience": "https://localhost:7247, http://localhost:5124, https://localhost:7205, http://localhost:5259"
}
```
### secrets.json (Web Service)
```JSON
{
  "ConnectionStrings:ProjectManagementDB": "Data Source=.;Initial Catalog=ProjectManagement;Integrated Security=True;Multiple Active Result Sets=True; TrustServerCertificate=true",
  "Jwt:Key": "41ACA650-21E8-409E-A3D5-95C3A1AAAB04",
  "Jwt:Issuer": "https://localhost:7247, http://localhost:5124, https://localhost:7205, http://localhost:5259",
  "Jwt:Audience": "https://localhost:7247, http://localhost:5124, https://localhost:7205, http://localhost:5259"
}
```

Ahora crearemos la base de datos mediante linea de comandos usando Entity Framework. Nos vamos al menu de arriba y seleccionamos en Herramientas / Administrador de Paquetes Nugget / Consola del Administrador de Paquetes.

![image](https://github.com/user-attachments/assets/7ee8e153-2fa9-4d27-be1e-753247502070)

Una vez tengamos abierta la consola digitamos "update-database" para crear la base de datos en nuestro servidor local.

![image](https://github.com/user-attachments/assets/164946a2-e4ac-43c0-a671-63307439cedc)

Finalmente ya tenemos el entorno configurado y listo para iniciar los proyectos, como mencione el inicio esta solucion esta configurada para levantar ambos proyectos a la vez, asi que solo tendremos que darle a "Iniciar"

![image](https://github.com/user-attachments/assets/0de89154-71db-4134-ab73-de1c3ed3d8cb)


## Consideraciones

- Con respecto a la conexion de base de datos, de preferencia colocar el nombre de tu servidor SQL local para evitar conflictos en la creacion de la base de datos.
- Los proyectos ya se encuentran configurados para funcionar en el entorno local por lo que no es necesario realizar ajustes extras.
- Las credenciales del usuario Administrador son las siguientes:
    - Email: jjimenez@gmail.com
    - Contraseña: $Test1234
