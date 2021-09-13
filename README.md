# Vejledningsbooking

Udarbejdet af Magnus, Nils, Sune og Mikkel

Vi har haft til opgave at gennemføre det første sprint af et Vejledningsbooking projekt. 

*"Underviserne ved UCL har brug for et vejledningsbooking system, således studerende kan booke vejledning i forbindelse med projektperioder."*

## Projektets krav, regler og roller

De funktionelle krav er følgende:
- En underviser kan have et antal kalendere (en kalender pr. hold).
- En kalender indeholder bookingvinduer.
- Et bookingvindue indeholder bookiner.

Reglerne er følgende:
- En booking skal kunne være indenfor et bookingvindues tidsramme.
- En booking må ikke overlappe med andre bookinger i samme bookingvindue.

Kalender og bookingvinduer oprettes af underviseren.
Bookinger oprettes af studerende.

## Opgaverne i første sprint

I første Sprint er vi blevet bedt om at udføre følgende opgaver:

* Udarbejd en domæne model (klasser og relationer).
* Implementér domænemodellen samt regler.
* Implementér persistering af domænemodellen.
* Implementering af følgende events:
  * Indlæs kalender.
  * Opret booking i et booking vindue.


## Løsning

### Domænet

Vi har identificeret en række entiteter/klasser som udgør domænet for projektet:

* Kalender
* BookingVindue
* Booking
* Hold
* Underviser
* Studerende

Vi har forsøgt at lave en domænemodel, som primært fokuserer på forholdet mellem Kalender, BookingVindue og Booking. Vi har kun påvist relationer til de tre sidste entiter, hvis de havde en relation til vores fokusområde.

Vi har lavet følgende antagelse om Underviser - Kalender - Hold relationerne:

*Et hold kan have flere undervisere. Et hold kan have flere kalendere, men kun én per tilknyttet underviser*  
KalenderId er en repræsentation af UnderviserId kombineret med HoldId.  

![Domænemodel](/design/Domænemodel.png)


### Arkitektur

Det var et krav, at vi benytte Clean Architecture. 
Derfor har vi fra start forsøgt at inddele programmet i forskellige projekter.
F.eks:
* Vejledningsbooking.Domain
* Vejledningsbooking.Application
* Vejledningsbooking.Persistence

Domain kender intet til de andre.  
Application kender til Domain.  
Persistence kender til Application og Domain.


### Implementering

**Domainlaget** indeholder alle vores grundlæggende klasser (entiter) . Det er også her vi har løst problemstillingen med de angivne regler for bookingvinduer og bookinger. Booking klassen kan checke om der er overlap med en anden booking eller om den kan passe ind i et givent bookingvindue.

BookingVindue klassen har så en metode AddBooking() som kun tillader tilføjelsen, hvis reglerne i Booking overholdes.

Vi har også valgt at lave interfaces til de forskellige domæneklasser, for at skabe mere fleksibilitet og afkobling. Alle referencer er til interfaces.
Undtagen i den lille Factory som vi har lavet, der sørger for at lave "new Klasse()" når der er brug for det.


**Applikationslaget** har vi designet meget tæt opad illustrationen fra "Clean Architectures.pdf" side 19 fra undervisningsmaterialet.
Handlinger er inddelt i Commands og der er oprettet et IDatabaseService interface, som bliver implementeret senere i Persistence laget.

Vi har oprettet en IndlæsKalenderCommand med et tilhørende interface. Her loades constructoren ind med en reference til IDatabaseService, som har en metode der kan returnere en kalender.


**Persistencelaget** har en DatabaseService klasse som implementere det interface der ligger i applikationslaget. Hernede foregår kontakt med databasen. Dette område har en midlertidig måde at anskaffe en Kalender ud fra et givent UnderviserId og HoldId. (Dog ikke afprøvet).
