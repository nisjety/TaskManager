# TaskManager
En oppgavebehandler for å håndtere dine oppgaver

KRISTIANIA
PG3302 Software design
Semesteroppgave

Del 1 - Planlegging:

-	Vi samlet oss for å finne på et prosjekt som kunne vise alt vi har lært i C#. Vi ville ha noe som dekket hele pensumet, men som også var praktisk.
-	Målet var å skape noe nyttig og enkelt, noe vi kunne bruke i hverdagen. Vi kom opp med tre ideer.
-	Til slutt bestemte vi oss for å lage en oppgavebehandler (TaskManager) som kunne holde styr på alt vi måtte gjøre.
-	Vi tenkte at det ville være flott med en app der man må logge inn. Slik at alle, enten det er studenter eller arbeidere, kan opprette en konto, logge inn, og ha sitt eget lille område i appen.
-	Vi bestemte at appen skulle være enkel å bruke. Brukerne kan legge inn oppgavene sine, organisere dem i en kalender, og så få varsler om dem.

Del 2 - Teknologi Valg:

-	Vi valgte programmer vi kjente best, som JetBrains Rider, siden vi begge bruker Mac. Dette verktøyet støtter både grensesnittutvikling og koding. For databasen gikk vi for SQLite, og PlantUML ble valgt for UML-diagrammer fordi det er gratis og enkelt å laste ned.
-	Vi besluttet å lage en skrivebordsapplikasjon for å gjøre testing og validering enklere. Dette fjernet behovet for serveroppsett eller nettbaserte løsninger, noe som gjør det lett for sensoren å teste programmet på egen hånd.

Del 3 - Kommunikasjon og Samarbeid:

-	Vi tenkte nøye på samarbeidet og kommunikasjonen. Vi valgte Git for versjonskontroll.
-	Kommunikasjonen foregikk hovedsakelig gjennom Facebook og telefon.
-	Vi prøvde å møttes på skolen for brainstorming for å få mest mulig ut av applikasjonen.

Del 4 - Program Liste:

-	Innlogging og registrering: Studenter kan registrere seg og logge inn på sin egen bruker.
-	Oppgavehåndtering: Her kan studenter legge til, redigere og slette studieoppgaver.
-	Kalenderintegrasjon: En kalender som viser oppgaver og eksamensdatoer basert på det studentene legger til.
-	Notathåndtering: Studenter kan skrive og lagre notater på valgte datoer.
-	Påminnelser: Sende varsler om kommende frister.
-	Ressurslenker: Mulighet til å legge til lenker til Zoom-møter, forelesningsvideoer, artikler, bilder, og så videre.

Del 5 - Fordeling av Oppgaver:

-	Siden vi var kun to i teamet, var det enkelt å fordele arbeidet. Vi delte opp funksjonene i applikasjonen vår mellom oss.
-	Vi laget en liste over alle oppgaver, og deretter valgte vi oppgavene som passet best etter ferdigheter og det vi kunne best fra listen.

Del 6 - Struktur:

-	For å få en klar idé om hva vi skulle lage, begynte vi med å skissere alle sidene i applikasjonen vår.
-	Vi brukte Figma for å designe de forskjellige sidene som logg inn-siden, brukersiden, oppgavesiden, kalendersiden, ressurssiden, notatsiden og så videre.
-	Deretter startet vi med UML-diagrammer for å planlegge klassene, attributtene, metodene og forholdene mellom dem.

Del 7: UML- design: 
-	Vi lastet ned PlantUML-utvidelsen i VS Code, som lar oss lage UML-diagrammer ved å skrive tekst. Dette gjorde det mye enklere og raskere for oss å forme og endre våre diagrammer.
-	Underveis innså vi at vårt første UML-diagram var for komplisert. For å følge SOLID-prinsippene bedre, forenklet vi designet ved å fjerne unødvendige klasser og gjøre funksjonene mer spesifikke og fokuserte.
-	Med PlantUML kunne vi raskt justere vårt design uten å måtte tegne hele diagrammet på nytt hver gang vi gjorde en endring. Dette gjorde hele prosessen mye mer fleksibel og mindre tidkrevende.
-	Vi hadde mange fine ideer, men vi valgte å fokusere på det viktigste først, og samtidig legge til rette for fremtidig utvikling. Vi brukte abstrakte klasser og grensesnitt for å definere generell oppførsel som spesifikke klasser kunne overta eller implementere.

Endringer i UML-diagrammet:
•	I vårt første UML-diagram hadde vi klasser som User, Task, Calendar, Notification, Note og Resource. Etter å ha tenkt gjennom SOLID-prinsippene, forenklet vi diagrammet ved å fjerne Notification og Resource, og integrerte deres viktige funksjoner i andre klasser.
•	User-klassen ble sentral i vår struktur, og vi styrket dens relasjoner til Task og Calendar, samt lagde en forbindelse til ProfileData for å holde brukerdata sentralisert.
Fokus på Enkelhet og Fleksibilitet:
•	Vi valgte SQL for databasestyringen fordi det er godt kjent og fleksibelt, og det gjør det enkelt for oss å håndtere data på en sikker måte.
•	Vi la til ProfileData for detaljert brukerinformasjon, en Image-klasse for profilbilder, og en Category-klasse for organisering av oppgaver.
•	Vi fjernet Notification-klassen for å gjøre brukergrensesnittet enklere og unngå kompleksiteten med brukervarslinger i denne versjonen av applikasjonen.
Tydelighet og Konsistens:
•	Ved å bruke Enum for ting som TaskStatus og RecurrenceType sørget vi for klarhet og unngikk behovet for ekstra relasjoner.
•	Vi passet på at hver klasse kun viste nødvendige detaljer, noe som gjorde brukerinteraksjonen enklere.

Del 7: Databaseoppsett og Plattformvalg og endring
-	Etter å ha ferdigstilt UML-diagrammet vårt, hadde vi en klar idé om hva vi trengte å gjøre. Neste skritt var å sette opp databasen.
-	Som brukere av Mac, valgte vi Datagrip fra JetBrains for å håndtere databasen vår.
-	Vi gikk for SQLite som vår databaseplattform og fulgte standard prosedyrer for å sette den opp.
-	UML-diagrammet vårt fungerte som en guide for å strukturere databasen.

Utfordring med Plattformvalg:
-	Når vi begynte å kode, møtte vi et dilemma. Som Mac-brukere måtte vi velge mellom en webapplikasjon eller en tverrplattform desktopapplikasjon.
-	Å lage en webapplikasjon virket enklest, men det gikk imot vår opprinnelige ide om en lokalt kjørende applikasjon uten nettbehov.
-	Vi vurderte .NET MAUI for en tverrplattform applikasjon eller ASP.NET for en webbasert løsning.
-	Til slutt valgte vi en webbasert løsning fordi den var enklere og passet innenfor det vi allerede hadde lært.
-	På 9.11.23 fikk vi beskjed om at vi ikke kunne bruke rammeverk, noe som satte begrensninger for planen vår. Vi kunne fortsatt ha laget en webapplikasjon ved å bruke HTML, CSS og JavaScript for frontenden, og koble den med backend via API, og lage en lokal server.
-	Men for å holde oss til kun C# og det vi hadde lært i faget, ble den eneste muligheten å lage en konsollapplikasjon som kjørte i terminalen. Dette gjorde framstillingen av applikasjonen enklere.
-	Dette betydde at alt arbeidet vi hadde gjort måtte endres. Vi trengte en ny plan, ny logikk, et nytt UML-diagram, en ny SQLite-database, og vi kunne droppe designet vi hadde laget i Figma, og holde oss til det grunnleggende.

Del 8 Konsolbasert Tilnærming
-	Ved utvikle en konsollbasert applikasjon i C#. Gjort det det slikt at vi forholdt oss innenfor kursets læringsmål og for å unngå behovet for ekstra teknologier eller rammeverk som css, html, javascript osv.
-	UML og Forenkling: I lys av dette valget, gjennomgikk vi UML-diagrammet vårt for å gjøre applikasjonen enklere og mer fokusert på kjernefunksjonaliteten. Vi omstrukturerte UML-en til å passe bedre med en konsollapplikasjon, noe som førte til fjerning av enkelte klasser og relasjoner.
-	Nå som applikasjonen skulle være en ren C# konsollapplikasjon. Forenklet det utviklingsprosessen og tillot oss å fokusere på de grunnleggende aspektene ved C# programmering og applikasjonslogikk.
-	Dette krevde en revurdering av både brukergrensesnittet og interaksjonsflyten. Vi justerte klasserelasjonene for å skape en mer lineær og enkel flyt, ideell for en konsollapplikasjon.
-	Ved å forenkle vår tilnærming og fokusere på en konsollbasert applikasjon, har vi oppnådd en klarere og mer målrettet utviklingsprosess. Dette har tillatt oss å konsentrere oss om de grunnleggende aspektene ved C# programmering, SOLID-prinsippene, og effektiv datahåndtering gjennom en forenklet SQLite-database. Den endelige utformingen av applikasjonen er nå godt tilpasset for å møte både kursets krav og de praktiske behovene til brukerne.
-	Nå var vi klare for å kode, hver klasse hadde sitt eget ansvarsområde,  åpen for utvidelse, og at vi har brukt grensesnitt og abstraksjoner for å holde ting fleksibelt og organisert. Med et solid grunnlag for å bygge vår TaskManager-applikasjon på en måte som er både brukervennlig og klar for fremtidig vekst og utvikling.


Del 9: Logikk og Utviklingsprosess:

Utvikling av Grunnleggende Logikk:
-	Vi startet med å utvikle syv grunnleggende klasser for applikasjonen vår. Hovedklassen, Program.cs, fungerer som startsiden hvor brukerne kan logge inn, registrere seg, eller avslutte applikasjonen.
-	En LoginManager-klasse ble opprettet for innlogging, og en RegistrationManager-klasse for brukerregistrering med brukernavn, passord og e-post.
-	En UTask-klasse ble implementert for å la brukerne legge inn og lagre oppgaver i databasen. Navnet UTask ble brukt fordi Task klasha med UDEén sin task.tasks.
-	UTaskManager-klassen ble introdusert for å gi brukerne en oversikt over deres oppgaver med funksjoner for å vise og slettebasert på ID.-
-	Klasser for databasehåndtering (SQLiteDatabaseManager) og autentisering (AuthenticationService) ble inkludert.


Del 11: Videreutvikling og Forbedringer:

-	Under koding endret(refraktor) vi vår tilnærming ved å inkludere en UTaskProgram-klasse for å forbedre brukeropplevelsen og strukturere applikasjonen mer effektivt.
-	Etter autentisering i LoginManager, blir brukerne ført til UTaskProgram.cs som viser alle oppgavene og gir muligheter for oppgavehåndtering gjennom UTaskManager. Brukere kan også logge ut eller avslutte applikasjonen fra denne klassen.
-	Når brukere logger ut, blir de omdirigert tilbake til Program.cs. Ved registrering, blir de ledet til RegistrationManager og tilbake til Program.cs etter registrering.
-	Kontinuerlig forbedring av brukerinteraksjon, meny-navigasjon, valghåndtering, validering, tilbakemeldinger, og brukerveiledning har bidratt til en mer brukervennlig og robust applikasjon.
-	Vi har fokusert på konsistens i brukergrensesnittet og klarhet i kommunikasjon med brukeren.
-	Applikasjonen er strukturert for å tillate fleksibel navigasjon mellom ulike funksjoner, med en tydelig separasjon av ansvarsområder i de forskjellige klassene
-	Vi gjorde flere oppdateringer i UML-diagrammet for å speile de nyeste endringene i arkitekturen til applikasjonen vår:

Introduksjon av UTaskProgram-klassen:
-	Under koding endret(refraktor) vi vår tilnærming ved å inkludere en UTaskProgram-klasse for å forbedre brukeropplevelsen og strukturere applikasjonen mer effektivt.
-	Denne klassen ble lagt til for å håndtere brukerspesifikke operasjoner etter innlogging, som for eksempel visning, legging til, og sletting av oppgaver. Tidligere skulle brukeren gå tilbake til Program-klassen for å håndtere oppgaver, men nå blir de sendt direkte til UTaskProgram-klassen for en mer effektiv oppgavehåndtering.
-	Etter autentisering i LoginManager, blir brukerne ført til program.cs som så sender vidre til UTaskProgram.
-	oppgavehåndtering ble fortsatt gjennom UTaskManager. Brukere kan også logge ut eller avslutte applikasjonen fra UTaskProgram.
-	Når brukere logger ut, blir de omdirigert tilbake til Program.cs. Ved registrering, blir de ledet til RegistrationManager og tilbake til Program.cs etter registrering

Oppdaterte Relasjoner Mellom Klasser:
-	Vi reviderte UML-diagrammet for å tydelig vise samspillet mellom Program, LoginManager, RegistrationManager, og UTaskProgram. Dette gir en bedre forståelse av hvordan disse klassene interagerer med hverandre i applikasjonen.
-	Justering av Metoder i Grensesnitt:
-	Endringer ble gjort i grensesnittene IUserManagement og IUTaskManagement for å sikre at metodene deres stemmer overens med den oppdaterte designen. Dette sikrer at alle deler av applikasjonen arbeider sammen på en konsistent og funksjonell måte.
-	Disse endringene i UML-diagrammet gjenspeiler den nye, forbedrede strukturen i applikasjonen vår, og bidrar til en mer effektiv og brukervennlig opplevelse. Ved å forenkle og reorganisere de grunnleggende komponentene, har vi oppnådd en bedre integrasjon og flyt i applikasjonen, noe som er essensielt for brukervennligheten og den generelle funksjonaliteten.



Del 9: Koding og Oppsett
Utviklingsmiljø og Plattformvalg:
-	Vi valgte JetBrains Rider som vårt hovedverktøy for utvikling fordi det passer perfekt med .NET 7, som var vår foretrukne plattform. Rider tilbød avanserte funksjoner som forbedret vår evne til å skrive og feilsøke kode.
-	For SQL-integrasjonen møtte vi noen utfordringer, men disse ble løst ved å følge installasjonsveiledningen nøye og sikre riktig konfigurasjon og velge riktig .net verson etter oppdateringen til .NET 8 den 14.11
Prosjektoppsett og Databaseintegrasjon:
-	Vi valgte en "code-first"-tilnærming som ga oss friheten til å utforme databasestrukturen dynamisk.
-	Entity Framework Core ble integrert for en effektiv og smidig interaksjon med databasen, sikrende at endringer i våre modeller ble korrekt implementert i SQLite-databasen.
Kodeorganisering og SOLID-prinsipper:
-	Vi utviklet sentrale modeller som User og UTask. User-modellen inneholdt ID, brukernavn, passord, e-postadresse, og en kobling til UTask.
-	En DatabaseContext-klasse ble opprettet for å håndtere interaksjon med databasen.
-	I kategorien "Utilities" inkluderte vi hjelpeklasser som DateTimeUtility for å hente dato og tid, InputValidator for å validere datainngang og AuthenticationService for passordsikkerhet og verfisere brukers innlogging status.
-	Viktige grensesnitt som IUserManagement og IUTaskManagement ble definert for å standardisere brukerhåndtering.
-	Under "Services" implementerte vi klasser som LoginManager, RegistrationManager og UTaskManager for innlogging, brukerregistrering og oppgave behandling.
-	I root hadde vi program og UTaskProgram som entri points og bruker interaksjoner til hver av klassene våres
-	Vi fulgte SOLID-prinsippene for å sikre en robust, vedlikeholdbar og utvidbar kodebase. Med mulighet for vidre refraktor
Sikkerhet og Dataintegritet:
-	Vi implimenterte sikkerhet for passordhåndtering ved å hashe passord før lagring.
-	Nøye validering av brukerdata ble prioritert for å sikre integriteten av informasjonen.
Spesifikke Forbedringer og Endringer:
-	Vi implementerte omfattende null-sjekker og håndterte potensielle null-referanser for å styrke applikasjonens robusthet.
-	Moderne "pattern matching"-funksjoner i C# ble tatt i bruk for bedre lesbarhet, spesielt i InputValidator-klassen.
-	Vi oppdaterte LoginManager for å integrere AuthenticationService for en mer sentralisert autentiseringslogikk.
-	Kodestilen og -konvensjonene ble oppdatert for å følge anbefalte praksiser, inkludert PascalCase-navngivning for statiske readonly-felt.
-	Vi forbedret feilhåndteringen og økte robustheten i brukergrensesnittet.

Del 10: Testing
Opprettelse av Enhetstester:
-	For å sikre at koden vår var av høy kvalitet, lagde vi enhetstester for viktige deler av applikasjonen som User, UTask, og InputValidator siden de ikke hadde sql implementeringer.
-	Disse testene ble skrevet i et eget prosjekt, noe som hjalp oss med å holde testkoden og selve applikasjonskoden separat.
Utvikling av Testmetodikk:
•	Vi brukte en enkel, men effektiv, metode for å teste uten å bruke et spesifikt rammeverk. Dette involverte manuelle sjekker og bruk av Console.WriteLine for å vise resultatene av testene.
•	Våre tester dekket mange forskjellige scenarier, inkludert både gyldige og ugyldige inndata, for å sikre at forretningslogikken i modellene våre var korrekt.
Håndtering av Uferdige Funksjoner:
•	Underveis i utviklingen møtte vi utfordringer med uferdige deler av prosjektet, som for eksempel SqlDatabaseManager var ikke ferdig og dermed ble ikke applikasjonen vår build. For å håndtere dette, kommenterte vi ut alle klassene som var avhengig av SqlDatabaseManager  for å midlertidig ekskludere disse delene fra byggeprosessen.
•	Dette ga oss muligheten til å konsentrere oss om og teste de delene av applikasjonen som var ferdige, uten å bli hindret av uferdig funksjonalitet.
Testing av Modeller og Valideringsklasser:
•	Testene av User-modellen fokuserte på gyldigheten av brukeropprettelsen og håndtering av unntak for ugyldige inndata.
•	For UTask, sjekket vi at konstruktørens logikk og oppdateringsmetodene for tittel, notat og forfallsdato virket som de skulle.
•	InputValidator-testene sjekket valideringslogikken for brukernavn, passord, e-post, oppgavetittel, notater og datoer.
Refleksjoner og Fremtidige Planer:
•	Våre tester bekreftet at de viktigste funksjonene i applikasjonen fungerte som forventet, noe som tyder på en solid kodebase.
•	Vi ser viktigheten av kontinuerlig testing så vi ikke havner i samme feil som nå ved å måtte kode ut deller av prosjektet.
•	 Vi er klare over at vi kunne brukt mock-test men dette planlegger  vi i fremtiden, kanskje også integrere automatiserte testingsteknikker og rammeverk som NUnit eller xUnit for å forbedre vår evne til å teste.

Konklusjon av Prosjektet
Gjennom hele prosessen med å utvikle en TaskManager-konsollapplikasjon, har vi navigert i et landskap av planlegging, teknologivalg, samarbeid, og systematisk utvikling for å skape en funksjonell og brukervennlig applikasjon. Vårt mål var å demonstrere det vi lærte i C#, samtidig som vi skapte noe nyttig og praktisk.

Vi valgte kjente verktøy som JetBrains Rider og SQLite, og brukte PlantUML for å forenkle UML-prosessen. Vår beslutning om å lage en skrivebordsapplikasjon endret seg til en webbasert løsning og til slutt en ren konsollapplikasjon i C#, på grunn av begrensninger i tilgjengelige teknologier og rammeverk vi kunne bruke. Dette krevde en tilbakevending til det grunnleggende og en revurdering av vår tilnærming, som påvirket både UML-diagrammet, databaseoppsettet og planen vår.

Vi organiserte applikasjonen vår rundt nøkkelmodeller som User og UTask, og implementerte viktige klasser og grensesnitt for å håndtere forskjellige aspekter av applikasjonen, som innlogging, brukerregistrering og oppgavehåndtering. Sikkerhet var en prioritet, spesielt i passordhåndteringen. Vi fulgte SOLID-prinsippene for å sikre en solid og vedlikeholdbar kodebase, og gjennomgikk kontinuerlig forbedringer og justeringer for å forbedre brukeropplevelsen og applikasjonens robusthet.

Testingen av applikasjonen omfattet både enhetstesting og manuelle tester for å sikre at applikasjonen oppfylte våre standarder for kvalitet og funksjonalitet. Vi håndterte utfordringer med uferdige funksjoner ved å midlertidig utelate dem fra byggeprosessen, slik at vi kunne fokusere på og teste de ferdige delene.
Prosjektet var ikke bare en teknisk utfordring, men også en læringsreise. Vi anerkjenner viktigheten av kontinuerlig testing og planlegger å integrere mer avanserte testingsteknikker i fremtiden. Til tross for endringer og utfordringer underveis, har vi utviklet en havlveis funksjonell TaskManager-applikasjon som demonstrerer våre ferdigheter i C# og sofware design.
