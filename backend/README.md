


 * Breve explicacion del proyecto.

 Creamos el proyecto en "ASP.NET Core Web API"
 Instalamos las dependencias para que no tengamos problemas ya:
 -->  Swagger ya viene instalada por default
 -->  Microsoft.EntityFrameworkCore.SqlServer
 -->  Microsoft.EntityFrameworkCore.Tools
 -->  Microsoft.VisualStudio.Web.CodeGeneration

 Creamos de lo primero una clase que se va a llamar "Curso" con sus atributos y la enlazamos con "BaseEntity"
 Creamos una clase llamada "BaseEntity"
 Creamos "ConnectionStrings" en appsettings.json
 Creamos "ProjectNetDBContext" --> Para crear la tabla cursos en Base de datos
 Creamos la migracion "add-migration "Create Cursos table"" despues --> "Update-Database -Verbose" --> "Script-Migration "
  * Una vez realizado estos pasos en en la aplicacion " SQL MANAGEM " aparecera la nueva base de datos
  * Y podremos conectar desde el " Explorador de Servidores " de .NET la base de datos que es lo mismo que el " SQL MANAGEM "
  Lo conectaremos poniendo "localhost\SQLEXPRESS" y abajo marcando la base de datos con el nombre que pusimos en "ConnectionStrings" en appsettings.json --> "ProjectNetDB"

  * ---------------_- Sesion 2 -_---------------
  Hacemos un controlador en Api --> controlador entity --> Que nos genera solo un controllador.
  Primer el nombre de la clase / la base de datos / el nombre del controlador
  Comprobamos que funcionan ok los metodos.


  - Falta por explicar el tema de la relaciones y herencias.

    * ---------------_- Sesion 3 -_---------------

   1- Entramos en nuevos conocimientos, pinchamos dentro de "Solucion" en Explorador de soluciones y le damos a agregar nuevo proyecto y agregamos un proyecto que
   es "Biblioteca de clases" y se nos genera dentro de la misma solucion, añadimos los "usins" correspondientes y creamos varias clases.

   2-En la clase "Snippets" hemos creado una serie de funciones con ejemplos para poder buscar x tipo de datos como si fueran consultas sql.

   3- En esta sesion vamos a ver como obtener "Elementos basicos de busqueda", "Elementos complejos de busqueda", "SALTAR ELEMENTOS (Skip,Take)"
   Son funciones de busqueda mucho mas avanzadas que nos sirven para implementarlas en los controladores para que no solo sean los tipicos get por id o cosas asi.
   Por que al fin y al cabo son consultas a nuesta base de datos.

   ##### Ejercicio 3 #####

