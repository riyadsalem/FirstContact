# FirstContact
> Korte oefening rond unit testing, mocks en het testen van interacties tussen objecten.

## Opdracht

Schrijf met xUnit en [NSubstitute](https://nsubstitute.github.io/) een volledige reeks unit tests voor `ContactService`.

De productiecode is klaar. Het is jouw taak om alle functionaliteit en elke
betekenisvolle interactie tussen `ContactService` en `IContactRepository` te
testen. Schrijf geen concrete implementatie van de repository, maar vervang de
repository in elke test een *substitute*.

## Wat moet je testen?

Test minstens de volgende scenario's.

### `AddContact`

- Een contact met de gevraagde naam wordt aan de repository doorgegeven.
- De response bevat het ID en de naam van het toegevoegde contact.

Ga ervan uit dat `IContactRepository.Add` een ID toekent aan het meegegeven
`Contact` voordat de methode terugkeert. Bij het testen van de response moet je
*substitute* dat gedrag nabootsen.

### `GetAll`

- Elk contact dat de repository teruggeeft, wordt correct naar de response
  gemapt.
- Als de repository een lege lijst teruggeeft, is ook de response leeg.

### `Search`

- De exacte zoekterm wordt aan de repository doorgegeven.
- Elk gevonden contact wordt correct naar de response gemapt.
- Als er geen contacten worden gevonden, is de response leeg.

### `UpdateContact`

- Als het contact bestaat, wordt de naam gewijzigd, wordt `Commit` aangeroepen
  en geeft de methode `true` terug.
- Als het contact niet bestaat, geeft de methode `false` terug en wordt `Commit`
  niet aangeroepen.

### `DeleteContact`

- Het juiste ID wordt aan de repository doorgegeven.
- Als de repository het contact succesvol verwijdert, geeft de methode `true`
  terug.
- Als de repository het contact niet kan verwijderen, geeft de methode `false`
  terug.

## Verwachtingen

- Volg het Arrange, Act, Assert-patroon.
- Geef tests een naam die het scenario en het verwachte resultaat beschrijft.
- Controleer waar nodig de teruggegeven waarden en gemapte gegevens.
- Verifieer aanroepen van de repository wanneer die deel uitmaken van het
  gedrag.
- Verifieer dat een interactie *niet* plaatsvindt wanneer de afwezigheid ervan
  belangrijk is.
- Houd elke test onafhankelijk en deterministisch.
- Wijzig de productiecode niet om een test te laten slagen.

Line coverage alleen is niet het doel. Een testreeks die elke regel uitvoert,
maar nooit de samenwerking met `IContactRepository` controleert, is onvolledig.

## Voorgestelde structuur van het testproject

Organiseer de tests volgens de methode die je test:

```text
FirstContact.Tests/
|-- ContactServiceTests/
|   |-- AddContactTests.cs
|   |-- DeleteContactTests.cs
|   |-- GetAllTests.cs
|   |-- SearchTests.cs
|   `-- UpdateContactTests.cs
`-- FirstContact.Tests.csproj
```

Elk bestand kan één testklasse met alle scenario's voor die methode bevatten.
Voer de volledige testreeks uit met:

```shell
dotnet test
```
