# $\text{-DIKO-}\sqrt{\text{REGGAE}}\text{-PREAMP-}$

[English version below](#english-version)

Dieses Repository zeigt die Entwicklung des DIKO ELEKTROTECHNIK Vorverstärkers, vom ersten Prototyp bis zum aktuellen Stand.

## Ordnerstruktur

- Blockschaltbilder
- Ältere Versionen
- KiCad Dateien
- Bilder
- Datenblätter
- 3D Druck

## Version 1 – Erster Prototyp

Version 1 entstand im Rahmen meiner Bachelorarbeit. Schaltpläne und Fertigungsdateien der Platinen wurden mit Altium Designer erstellt. Das Besondere an dieser Version: Die analoge Frequenzweiche lässt sich über Digitalpotentiometer digital einstellen.

**Hinweis: Version 1 ist fehlerhaft!**

## Version 2 – Rein analoger Aufbau

Version 2 baut auf den Erkenntnissen aus Version 1 auf und bringt komplett neue Platinen mit. Die Digitalpotentiometer sind entfallen, da der Vorverstärker einfacher werden und der Fokus zunächst auf der analogen Schaltungstechnik liegen sollte.

Bei den bisherigen Tests wurden schaltungstechnisch keine Fehler gefunden. Trotzdem gibt es zwei Schwachstellen:

- Das Platinenlayout ist nicht zufriedenstellend.
- Der Mikrofonvorverstärker verstärkt das Signal nicht ausreichend.

Aus diesen Gründen wird nun an Version 3 gearbeitet.

## Version 3 – Modularer Aufbau (aktueller Stand)

Version 3 teilt den Vorverstärker in einzelne Komponenten auf, die sich miteinander verbinden lassen.

2026_10_05 Den Anfang macht die Frequenzweiche, die sich auch eigenständig mit einem externen Mischpult nutzen lässt.

---

# English Version

This repository documents the development of the DIKO ELEKTROTECHNIK preamplifier, from the first prototype to the current state.

## Folder Structure

- Blockschaltbilder (block diagrams)
- Ältere Versionen (older versions)
- KiCad Dateien (KiCad files)
- Bilder (images)
- Datenblätter (datasheets)
- 3D Druck (3D printing)

## Version 1 – First Prototype

Version 1 was developed as part of my bachelor's thesis. The schematics and PCB manufacturing files were created with Altium Designer. What makes this version special: the analog crossover can be adjusted digitally using digital potentiometers.

**Note: Version 1 is faulty!**

## Version 2 – Purely Analog Design

Version 2 builds on the findings from Version 1 and comes with completely new PCBs. The digital potentiometers were removed to make the preamp simpler and to focus on the analog circuitry first.

So far, testing has not revealed any circuit errors. However, there are two weak points:

- The PCB layout is not satisfactory.
- The microphone preamp does not amplify the signal sufficiently.

For these reasons, work is now underway on Version 3.

## Version 3 – Modular Design (current state)

Version 3 splits the preamp into individual components that can be connected to each other.

2026_10_05 The first step is the crossover, which can also be used on its own with an external mixing console.
