# Projektgranskning (Audit)

**Datum:** 2026-11-09
**Granskare:** Saadaq Mohamud Ali

## Steg 1: Starta från noll (Anteckningar)
* **Fynd vid kloning:** README-filen nämner att databasen ska köras igång, men det saknas exakta kommandon för att sätta upp PostgreSQL/pgvector-containern via Docker, och kommandot för Entity Framework migrations saknades.
* **Frontend:** Jag var tvungen att gissa mig till att köra `npm install` och `npm run dev` eftersom det inte stod explicit i README.

---

## Steg 2: Checklista (0-2 poäng)
*0 = Saknas, 1 = Finns lite/Delvis, 2 = Sitter bra*

### Hur koden är byggd
- [1] **Är controllers tunna, och ligger logiken i services?** (De flesta är tunna, men i några endpoints ligger det kvar affärslogik och direkt databasanrop).
- [1] **Används DTOs, eller skickas databasobjekten rakt ut till frontend?** (Används oftast vid POST/PUT, men i några GET-anrop läcker hela databasmodellen ut).
- [2] **Är frontend uppdelad på ett sätt som går att hitta i?** (Bra struktur med separata mappar för komponenter, hooks och sidor).

### Hur koden mår
- [1] **Finns det tester, och går de att köra med ett enda kommando?** (Vi har e2e-tester uppsatta, men saknar isolerade enhetstester för backendens services).
- [1] **Kollar servern själv att datan är rimlig?** (Vi har lite FluentValidation, men litar lite för mycket på frontendens formulärvalidering ibland).
- [1] **Får användaren ett vettigt besked när något går fel?** (API:et kastar ibland råa 500-fel istället för strukturerade problemdetaljer/JSON).
- [0] **Visar React att något laddar, och vad som händer när listan är tom?** (Ofta visas bara en vit skärm innan datan hämtats, och inga snygga "Empty States" när databasen är tom).

### Hur repot fungerar för ett team
- [1] **Räcker README för att någon annan ska kunna starta projektet?** (Saknar miljövariabler/connection strings-exempel och exakta startkommandon).
- [2] **Är bin, obj och node_modules utanför git?** (Ja, .gitignore är korrekt konfigurerad).
- [2] **Finns det lösenord eller nycklar i koden?** (Nej, allt ligger säkert i user secrets eller .env).
- [1] **Ser commit-historiken ut som en berättelse?** (Historiken innehåller en del otydliga meddelanden som "fix", "update", "testar").
- [0] **Är koden formaterad på samma sätt överallt?** (Koden har lite olika formatering, vi kör varken `dotnet format` eller `prettier` automatiskt via scripts).

---

## Steg 3: De fem viktigaste förbättringarna (Mina Issues)
1. **Uppdatera README.md med fullständiga startinstruktioner för lokala miljöer (inkl. DB).**
2. **Implementera Loading Spinners och "Empty States" i React-gränssnittet.**
3. **Städa controllers och inför DTO:er på alla GET-endpoints för att stoppa dataläckage.**
4. **Inför en global felhanterare (Global Exception Handler) i .NET för standardiserade felmeddelanden.**
5. **Lägg till Prettier och .NET Format-scripts för enhetlig kodformatering.**