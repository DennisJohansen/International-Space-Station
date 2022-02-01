# International Space Station

Time spend: 3 hours 20 minutes

## Starting the solution

    dotnet run

## Highlights
Collector project with 10 sec sampling of data to give statistics - storage in CSV file
Swagger implemented, ready for extension:

> http://localhost:5104/swagger

Docker ready for deployment
Authorization Header Key Middleware

## Because time where limited
Because of time limitations, shortcuts was made:
Unit tests - project was created but not implemented
Resilience and typesafety - could be greatly improved, implemented based on "happy path"
Better abstraction - A more common abstraction could be made on for example the CSV handling
Data storage - in a cloud setup the solution would benefit from storing data in for example TableStorage
