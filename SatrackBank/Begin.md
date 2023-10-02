# Instrucciones para desarrolladores.

## Comando para ejecutar migraciones.
``add-migration InitialCreate -p SatrackBank.Repositories.EFCore -c SatrackBankContext -o Migrations -s SatrackBank.Repositories.EFCore``

## Comando para actualizar la base de datos.
``update-database -p SatrackBank.Repositories.EFCore -s SatrackBank.Repositories.EFCore``

