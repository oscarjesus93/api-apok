Proyecto Prueba Tecnica PT - Oscar Sanchez
Instrucciones para la ejecucion del proyecto:
1. Abrir linea de comandos CMD
2. Ir a la carpeta Api (Proyecto API) y tipear los siguientes comandos
3. docker-compose up --build -d -> Crea el contenedor y 2 servicios, la api estara expuesta en el puerto 8181 -> http://localhost:8081
4. dotnet ef database update    -> Ejecutara la migracion dentro del proyecto en la base de datos de psotgres

Requisitos:
1. Docker instalado
2. SDK de .NET, preferiblemente la version 8
