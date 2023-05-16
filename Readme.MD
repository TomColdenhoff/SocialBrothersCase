# .NET/C# API Case
## Opstarten
Om het project te starten, moet je het eerst klonen. Nadat je het project hebt gekloond, kun je het openen in de IDE van jouw keuze en het starten vanuit de IDE.
Wil je het project via de command line opstarten? Doe dan het volgende:

Voor http:
```bash 
dotnet run --project SocialBrothersCase.API --launch-profile "http"
```
Voor https:
```bash 
dotnet run --project SocialBrothersCase.API --launch-profile "https"
```

---
Mocht er geen SQLite database aanwezig zijn, dan moet het volgende commando ook uitgevoerd worden om deze aan te maken:
```bash 
dotnet ef database update -p SocialBrothersCase.Database -s SocialBrothersCase.API 
```

## Gebruiken

Nadat de applicatie is opgestart, biedt deze een HTTP API aan waarmee de applicatie kan worden gebruikt. De documentatie hiervoor is te vinden op https://localhost:7122/swagger/index.html of http://localhost:5013/swagger/index.html.

### Functionaliteiten
De applicatie biedt de volgende functionaliteiten:
- Adres gegevens CRUD
- Hemelsbrede afstand in kilometers berekenen tussen twee adressen.

## Reflectie
### Algemeen
Ik heb de applicatie gebouwd met een CQRS-architectuur, waardoor ik mijn controllerklasse klein kon houden en de functionaliteiten modulair kon opdelen in kleinere klassen.

### Filteren
Verder heb ik voor het filteren en het sorteren extensie methodes geschreven voor ```IQueryable```. 
In deze methoden heb ik met behulp van reflectie een expressieboom kunnen bouwen waarmee ik dynamisch een Where- of OrderBy-methode kon genereren voor elk type object. 
In de huidige versie ondersteun ik alleen properties van het type string, maar als ik ook andere typen wil ondersteunen, zou ik dit doen met behulp van een factory- en strategy patroon. 
Hiermee kan ik op een schaalbare manier conversielogica schrijven voor meerdere typen.
