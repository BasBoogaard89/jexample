# JEXample, het Allround Match Platform voor Loopbaan en Ervaring
Dit project bevat een .NET REST API met optionele frontend voor het beheren van bedrijven en vacatures. Gebouwd als onderdeel van een assessment.

## Architectuur
- Clean architecture met scheiding van lagen functonaliteit
- Generieke BaseController, BaseService en BaseRepository als basismethodes
- Specifieke Controller, Service en Repository voor specifieke functionaliteit
- Automapper voor model mapping (DTO -> Entity en vice versa)
- InMemory EF database
- Frontend Api generator, maakt endpoints beschikbaar als typescript

## Backend
1. Open de solution in Visual Studio
2. Start het Api project
3. Ga naar url `http://localhost:5177/scalar/v1` voor de endpoint documentatie
4. Aan de linkerkant staan de controllers en endpoints, aan de rechterkant kun je ze testen

### User story 1
- GET `/Company` -> toont lijst van bedrijven
- GET `/Company/{id}` -> toont specifiek bedrijf
- POST `/Company` -> update bestaand bedrijf, of voegt nieuwe toe als id = 0
- DELETE `/Company/{id}` -> specifiek bedrijf wordt verwijderd

Hetzelfde principe geld voor de /Vacancy endpoints.

### User story 2
Opgevangen in de GET `/Company/GetAllFiltered` methode, deze verwacht een uitbreidbaar filter object, voorlopig alleen de boolean waarde onlyWithActiveVacancies opgenomen, door deze op true te zetten worden alleen bedrijven met vacatures getoond.

### User story 3
Vacature aanmaken kan via het POST `/Vacancy` endpoint
Validatie gebeurd met `[Required]` annotaties, en wordt intern gecheckt

## Frontend
De endpoints zijn de testen in een eenvoudige frontend. 

1. Ga naar de Frontend map
2. Voer uit:
	- npm install
	- npm start
3. Open in je browser `http://localhost:4200`
4. Werktie niet? Draait de backend wel?

