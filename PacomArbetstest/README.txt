1. ModRSsim2 används för att simulera en del av Modbus protokollet över TCP. Så det går att testa en Modbus TCP server med hjälp av detta program.
2. För att testa en Modbus TCP server med ModRSsim2, följ dessa steg:
   a. Ladda ner och installera ModRSsim2 från den officiella webbplatsen eller en betrodd källa.
   b. Starta ModRSsim2 programmet.
   c. Konfigurera ModRSsim2 för att fungera som en Modbus TCP klient:
	  - Gå till "Connection" menyn och välj "TCP/IP".
	  - Ange IP-adressen och portnumret för den Modbus TCP server du vill testa.
	  - Klicka på "Connect" för att etablera en anslutning.
   d. När anslutningen är etablerad kan du börja skicka Modbus-förfrågningar till servern:
	  - Välj den typ av Modbus-förfrågan du vill skicka (i detta fall Coils).
   e. Granska svaret från servern i ModRSsim2 gränssnittet för att verifiera att servern fungerar korrekt och returnerar förväntade data.

3. Jag har använt en lokal databas, så för att skapa en ny databas kan du följa dessa steg:
   a. Öppna Pakage Manager Console i Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
   b. Kör följande kommando för att skapa en ny databas med Entity Framework Core:
	  Update-Database

4. Starta applikationen genom att köra den i Visual Studio (F5 eller Ctrl+F5).
	a. Här finns 3 knappar för att ändra status på Coils:

5. Statusen på Coils sparas i databasen, så när du ändrar status på en Coil med knapparna på sidan så kommer den att behålla sin status.
   Första gången du startar applikationen så kommer alla Coils hämtas från ModRSsim2 och sparas i databasen. I detta fall 1, 4 och 5.