#include <SPI.h>

#define WRITE_CMD 0x00


const int numEntries = 96;  // Maximale Anzahl der Einträge, die pro Block eingelesen werden

// Struktur für die gespeicherten Daten
struct DataEntry {
  int csPin;
  long address;
  int associatedValue;
};

// Array, das die empfangenen Daten speichert
DataEntry dataEntries[numEntries];

void setPotiValue(int csPin, long address, int value) {
  byte commandByte = (address << 4) | WRITE_CMD;  // WRITE_CMD ist 0x00
  byte dataByte = value;  

  pinMode(csPin, OUTPUT);  // Chip-Select als Ausgang definieren

  digitalWrite(csPin, LOW);  // Chip-Select aktivieren (LOW)
  digitalWrite(csPin, LOW);  // Chip-Select aktivieren (LOW)
  SPI.transfer(commandByte);  // Befehl senden
  SPI.transfer(dataByte);  // Wert senden
  digitalWrite(csPin, HIGH);  // Chip-Select deaktivieren (HIGH)
}

void setup() {

  Serial.begin(9600);  // Seriellen Monitor starten
  SPI.begin();  // SPI starten
  SPI.beginTransaction(SPISettings(100000, MSBFIRST, SPI_MODE0));
  
}

void loop() {
  int index = 0;

  // Wir lesen Zeile für Zeile und speichern die Daten
  while (Serial.available() > 0 && index < numEntries) {
    String data = Serial.readStringUntil('\n');  // Daten bis zum nächsten Zeilenumbruch lesen

    if (data.length() > 0) {
      int firstCommaIndex = data.indexOf(',');
      String chipSelect = data.substring(0, firstCommaIndex);
      dataEntries[index].csPin = chipSelect.toInt();

      String restOfData = data.substring(firstCommaIndex + 1);
      int secondCommaIndex = restOfData.indexOf(',');

      String adress = restOfData.substring(0, secondCommaIndex);
      dataEntries[index].address = adress.toInt(); 

      String associatedValue = restOfData.substring(secondCommaIndex + 1);
      dataEntries[index].associatedValue = associatedValue.toInt();

      index++;  // Zum nächsten Eintrag weitergehen
    }
  }
  // Verarbeite die gespeicherten Daten und sende sie an das Digipot
  for (int i = 0; i < index; i++) {
    setPotiValue(dataEntries[i].csPin, dataEntries[i].address, dataEntries[i].associatedValue);
  }

  //delay(10);  // Kleine Pause zwischen den Blöcken (optional)
}