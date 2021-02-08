# DigitalWareII_APP

### Funcionalidades UX:
- Permite al usuario registrarse
- Permite al usuario hacer login para acceder a la aplicación
- Mensajes de alerta
- Cambiar la apariencia (colores) de la aplicación
- Cerrar sesión
- App Responsive

### Características tecnicas APP
- ForntEnd: Framework Angular
- Componentes de estilo y diseño:
    - Templates, iconos y estilos: https://www.wrappixel.com
    - Alertas: https://sweetalert2.github.io
    
- BackEnd: FrameWork .NetCore
  - API Rest
  - Db SQL Server
  
**Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas.**
**Pre-requisitos**

* .Net Core 5.0
* Sql Server 2016 o superior
* Sql Management studio 2016 o superior
* Visual studio 2019
* NPM de NodeJs
* Angular CLI

- Opcionales
    1. SourceTree (Cliente para manejo de git)

**Compilación**
1. Desrcargar o clonar el proyecto
2. Abrir la carpeta donde se encuentra ubicado el proyecto
  - Pasos DB:
    1. Sql Management
    2. Conectar a localhost con su respectivos usuario y contraseña
    3. Abrir la carpeta DW_DataBase
    4. Ejecutar Scritp 01 y 02 en Sql Management
   - Pasos Backend:
        1. Abrir la carpeta DW_Api
        2. Abrir la solución en Visual Studio 2019 (**Preferiblemente**)    
        3. En la pestaña *Solution Explorer (Explorador de la solución)* haga click derecho sobre la solución y seleccione la opción *Clean (Limpiar)*
        4. En la pestaña *Solution Explorer (Explorador de la solución)* haga click derecho sobre la solución y seleccione la opción *Build Solution (Compilar)*
        5. Abrir el archivo appsettings.json en la sección "ConnectionStrings" y modificar las llaves "ConexionDB" según el tipo de logeo que realizo en Sql Management.
       **NOTA:** Si el login en Sql Management lo tiene con autentiucación de windows dejar la configuración como se encuentra
        6. Haga click en el botón Play(IIS Express) o oprima la tecla F5
        7. Espere que se compile la solución y se abra la ventana de Swagger
   - Pasos FrontEnd:
        1. Abrir un símbolo del sistema y navegar dentro de la carpeta DW_Web.
        2. Ejecutar comando **npm install**
        3. Despues de que termine la instalación de las dependencias, ejecutar el comando **ng serve -o**
        4. Espere que se compile la solución y se abra la ventana localhost **http://localhost:4200/**
  
**Autores**

* Yoe Cardenas - Desarrollador full stack
