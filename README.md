# Vejledningsbooking

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

1. Udarbejd en domæne model (klasser og relationer).
2. Implementér domænemodellen samt regler.
3. Implementér persistering af domænemodellen.
4. Implementering af følgende events:
  4. Indlæs kalender.
  4. Opret booking i et booking vindue.


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


![Domænemodel](/design/Domænemodel.png)



