using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frequenzweiche_Test
{
    public partial class Form1 : Form
    {
        // Datei-Pfade zu den CSV-Dateien
        private readonly string fgCsvFilePath1 = "fg_1.csv";
        private readonly string digiCsvFilePath1 = "digi_1.csv";
        private readonly string fgCsvFilePath2_SUB = "fg_2_SUB.csv";
        private readonly string digiCsvFilePath2_SUB = "digi_2_SUB.csv";
        private readonly string fgCsvFilePath2_KICK = "fg_2_KICK.csv";
        private readonly string digiCsvFilePath2_KICK = "digi_2_KICK.csv";
        private readonly string fgCsvFilePath3_KICK = "fg_3_KICK.csv";
        private readonly string digiCsvFilePath3_KICK = "digi_3_KICK.csv";
        private readonly string fgCsvFilePath3_MID = "fg_3_MID.csv";
        private readonly string digiCsvFilePath3_MID = "digi_3_MID.csv";
        private readonly string fgCsvFilePath4_MID = "fg_4_MID.csv";
        private readonly string digiCsvFilePath4_MID = "digi_4_MID.csv";
        private readonly string fgCsvFilePath4_HI = "fg_4_HI.csv";
        private readonly string digiCsvFilePath4_HI = "digi_4_HI.csv";
        private readonly string fgCsvFilePath5 = "fg_5.csv";
        private readonly string digiCsvFilePath5 = "digi_5.csv";

        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
        }

        // ComboBox 1 - Auswahl für fg_1.csv und digi_1.csv
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFrequency = comboBox1.SelectedItem?.ToString().Trim();

            if (string.IsNullOrEmpty(selectedFrequency))
            {
                MessageBox.Show("Bitte wählen Sie eine Grenzfrequenz aus.", "Fehler");
                return;
            }

            try
            {
                // Die Werte für fg_1.csv
                var fgValues = GetFgValues(fgCsvFilePath1, selectedFrequency);

                // Die Werte für digi_1.csv
                var (closestValues, associatedValues) = GetClosestValues(digiCsvFilePath1, fgValues);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}", "Fehler");
            }
        }

        // ComboBox 2 - Auswahl für fg_2_SUB.csv, digi_2_SUB.csv, fg_2_KICK.csv und digi_2_KICK.csv
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFrequency = comboBox2.SelectedItem?.ToString().Trim();

            if (string.IsNullOrEmpty(selectedFrequency))
            {
                MessageBox.Show("Bitte wählen Sie eine Grenzfrequenz aus.", "Fehler");
                return;
            }

            try
            {
                // Die Werte für fg_2_SUB.csv und digi_2_SUB.csv
                var fgValuesSub = GetFgValues(fgCsvFilePath2_SUB, selectedFrequency);
                var (closestValuesSub, associatedValuesSub) = GetClosestValues(digiCsvFilePath2_SUB, fgValuesSub);

                // Die Werte für fg_2_KICK.csv und digi_2_KICK.csv
                var fgValuesKick = GetFgValues(fgCsvFilePath2_KICK, selectedFrequency);
                var (closestValuesKick, associatedValuesKick) = GetClosestValues(digiCsvFilePath2_KICK, fgValuesKick);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}", "Fehler");
            }
        }

        // ComboBox 3 - Auswahl für fg_3_KICK.csv, digi_3_KICK.csv, fg_3_MID.csv und digi_3_KICK.csv
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFrequency = comboBox3.SelectedItem?.ToString().Trim();

            if (string.IsNullOrEmpty(selectedFrequency))
            {
                MessageBox.Show("Bitte wählen Sie eine Grenzfrequenz aus.", "Fehler");
                return;
            }

            try
            {
                // Die Werte für fg_3_KICK.csv und digi_3_KICK.csv
                var fgValuesKick3 = GetFgValues(fgCsvFilePath3_KICK, selectedFrequency);
                var (closestValuesKick3, associatedValuesKick3) = GetClosestValues(digiCsvFilePath3_KICK, fgValuesKick3);

                // Die Werte für fg_3_MID.csv und digi_3_MID.csv
                var fgValuesMid3 = GetFgValues(fgCsvFilePath3_MID, selectedFrequency);
                var (closestValuesMid3, associatedValuesMid3) = GetClosestValues(digiCsvFilePath3_MID, fgValuesMid3);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}", "Fehler");
            }
        }
        // ComboBox 4 - Auswahl für fg_4_MID.csv, digi_3_MID.csv, fg_4_HI.csv und digi_4_HI.csv
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFrequency = comboBox4.SelectedItem?.ToString().Trim();

            if (string.IsNullOrEmpty(selectedFrequency))
            {
                MessageBox.Show("Bitte wählen Sie eine Grenzfrequenz aus.", "Fehler");
                return;
            }

            try
            {
                // Die Werte für fg_4_MID.csv und digi_4_MID.csv
                var fgValuesMid4 = GetFgValues("fg_4_MID.csv", selectedFrequency);
                var (closestValuesMid4, associatedValuesMid4) = GetClosestValues("digi_4_MID.csv", fgValuesMid4);

                // Die Werte für fg_4_HI.csv und digi_4_HI.csv
                var fgValuesHi4 = GetFgValues("fg_4_HI.csv", selectedFrequency);
                var (closestValuesHi4, associatedValuesHi4) = GetClosestValues("digi_4_HI.csv", fgValuesHi4);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}", "Fehler");
            }
        }
        // ComboBox 5 - Auswahl für fg_5.csv und digi_5.csv
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFrequency = comboBox5.SelectedItem?.ToString().Trim();

            if (string.IsNullOrEmpty(selectedFrequency))
            {
                MessageBox.Show("Bitte wählen Sie eine Grenzfrequenz aus.", "Fehler");
                return;
            }

            try
            {
                // Die Werte für fg_5.csv (Änderung hier)
                var fgValues = GetFgValues(fgCsvFilePath5, selectedFrequency);

                // Die Werte für digi_5.csv (Änderung hier)
                var (closestValues, associatedValues) = GetClosestValues(digiCsvFilePath5, fgValues);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}", "Fehler");
            }
        }



        // Holt Widerstandswerte aus einer fg-Datei für eine gegebene Grenzfrequenz
        private double[] GetFgValues(string fgFilePath, string selectedFrequency)
        {
            var fgLines = File.ReadAllLines(fgFilePath);

            var fgValues = fgLines.Skip(1) // Header überspringen
                                   .Select(line => line.Split(';')) // Zeile aufteilen
                                   .FirstOrDefault(fields => fields[0].Trim() == selectedFrequency); // Frequenz vergleichen

            if (fgValues == null)
            {
                throw new Exception($"Keine Daten für {selectedFrequency} Hz in der Datei {Path.GetFileName(fgFilePath)} gefunden.");
            }

            // Widerstandswerte aus fg-Datei einlesen
            double R_1 = ParseDouble(fgValues[1]);
            double R_2 = ParseDouble(fgValues[2]);
            double R_3 = ParseDouble(fgValues[3]);
            double R_4 = ParseDouble(fgValues[4]);

            return new double[] { R_1, R_2, R_3, R_4 };
        }

        // Konvertiert einen String in einen Double-Wert, gibt -1 zurück, falls der Wert ungültig ist
        private double ParseDouble(string value)
        {
            return double.TryParse(value.Trim(), out double result) ? result : -1;
        }

        // Holt die nächstgelegenen Werte aus einer digi-Datei für die gegebenen R_1, R_2, R_3 und R_4
        private (double[] closestValues, string[] associatedValues) GetClosestValues(string digiFilePath, double[] fgValues)
        {
            var digiLines = File.ReadAllLines(digiFilePath);

            var digiData = digiLines.Skip(1) // Header überspringen
                                     .Select(line => line.Split(';'))
                                     .Select(fields => new
                                     {
                                         Wert = fields[0].Trim(),
                                         R_1 = ParseDouble(fields[1]),
                                         R_2 = ParseDouble(fields[2]),
                                         R_3 = ParseDouble(fields[3]),
                                         R_4 = ParseDouble(fields[4])
                                     })
                                     .Where(data => data.R_1 != -1 && data.R_2 != -1 && data.R_3 != -1 && data.R_4 != -1)
                                     .ToList();

            // Berechne die nächstgelegenen Werte für R_1, R_2, R_3 und R_4
            double[] closestValues = new double[4];
            string[] associatedValues = new string[4];

            closestValues[0] = digiData.OrderBy(data => Math.Abs(data.R_1 - fgValues[0])).First().R_1;
            associatedValues[0] = digiData.OrderBy(data => Math.Abs(data.R_1 - fgValues[0])).First().Wert;

            closestValues[1] = digiData.OrderBy(data => Math.Abs(data.R_2 - fgValues[1])).First().R_2;
            associatedValues[1] = digiData.OrderBy(data => Math.Abs(data.R_2 - fgValues[1])).First().Wert;

            closestValues[2] = digiData.OrderBy(data => Math.Abs(data.R_3 - fgValues[2])).First().R_3;
            associatedValues[2] = digiData.OrderBy(data => Math.Abs(data.R_3 - fgValues[2])).First().Wert;

            closestValues[3] = digiData.OrderBy(data => Math.Abs(data.R_4 - fgValues[3])).First().R_4;
            associatedValues[3] = digiData.OrderBy(data => Math.Abs(data.R_4 - fgValues[3])).First().Wert;

            return (closestValues, associatedValues);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Alle Frequenzen aus den ComboBoxen abrufen und verarbeiten
            var frequencies = new List<string>();

            // Kombinieren der Werte aus allen ComboBoxen
            if (comboBox1.SelectedItem != null) frequencies.Add(comboBox1.SelectedItem.ToString().Trim());
            if (comboBox2.SelectedItem != null) frequencies.Add(comboBox2.SelectedItem.ToString().Trim());
            if (comboBox3.SelectedItem != null) frequencies.Add(comboBox3.SelectedItem.ToString().Trim());
            if (comboBox4.SelectedItem != null) frequencies.Add(comboBox4.SelectedItem.ToString().Trim());
            if (comboBox5.SelectedItem != null) frequencies.Add(comboBox5.SelectedItem.ToString().Trim());

            if (frequencies.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie mindestens eine Grenzfrequenz aus.", "Fehler");
                return;
            }

            // Laden der Chip_Select.csv-Datei
            var chipSelectData = LoadChipSelectData("Chip_Select.csv");

            // Variable zur Sammlung der gesendeten Werte
            StringBuilder sentData = new StringBuilder();

            try
            {
                // Schleife durch alle Frequenzen, die der Benutzer ausgewählt hat
                foreach (var frequency in frequencies)
                {
                    // Daten für ComboBox1 - fg_1.csv, digi_1.csv
                    if (comboBox1.SelectedItem != null && frequency == comboBox1.SelectedItem.ToString().Trim())
                    {
                        var fgValues = GetFgValues(fgCsvFilePath1, frequency);
                        var (closestValues, associatedValues) = GetClosestValues(digiCsvFilePath1, fgValues);

                        // Senden der Werte über die serielle Schnittstelle
                        for (int i = 0; i < closestValues.Length; i++)
                        {
                            string chipSelect = GetChipSelectForResistance(chipSelectData, $"R_{i + 1}");
                            string adress = GetadressForResistance(chipSelectData, $"R_{i + 1}");
                            SendValuesToArduino(closestValues[i], associatedValues[i], chipSelect, adress);

                            // Gesendete Werte in den StringBuilder für das Log aufnehmen
                            sentData.AppendLine($"R_{i + 1}: {closestValues[i]} Ω Wert: {associatedValues[i]} ChipSelect: D{chipSelect} adress:{adress}");
                        }
                    }

                    // Daten für ComboBox2 - fg_2_SUB.csv, digi_2_SUB.csv, fg_2_KICK.csv, digi_2_KICK.csv
                    if (comboBox2.SelectedItem != null && frequency == comboBox2.SelectedItem.ToString().Trim())
                    {
                        var fgValuesSub = GetFgValues(fgCsvFilePath2_SUB, frequency);
                        var (closestValuesSub, associatedValuesSub) = GetClosestValues(digiCsvFilePath2_SUB, fgValuesSub);

                        var fgValuesKick = GetFgValues(fgCsvFilePath2_KICK, frequency);
                        var (closestValuesKick, associatedValuesKick) = GetClosestValues(digiCsvFilePath2_KICK, fgValuesKick);

                        // Senden der Werte über die serielle Schnittstelle
                        for (int i = 0; i < closestValuesSub.Length; i++)
                        {
                            string chipSelect = GetChipSelectForResistance(chipSelectData, $"R_{i + 5}");
                            string adress = GetadressForResistance(chipSelectData, $"R_{i + 5}");
                            SendValuesToArduino(closestValuesSub[i], associatedValuesSub[i], chipSelect, adress);

                            // Gesendete Werte in den StringBuilder für das Log aufnehmen
                            sentData.AppendLine($"R_{i + 5}: {closestValuesSub[i]} Ω Wert: {associatedValuesSub[i]} ChipSelect: D{chipSelect} adress:{adress}");
                        }

                        for (int i = 0; i < closestValuesKick.Length; i++)
                        {
                            string chipSelect = GetChipSelectForResistance(chipSelectData, $"R_{i + 9}");
                            string adress = GetadressForResistance(chipSelectData, $"R_{i + 9}");
                            SendValuesToArduino(closestValuesKick[i], associatedValuesKick[i], chipSelect, adress);

                            // Gesendete Werte in den StringBuilder für das Log aufnehmen
                            sentData.AppendLine($"R_{i + 9}: {closestValuesKick[i]} Ω Wert: {associatedValuesKick[i]} ChipSelect: D{chipSelect} adress:{adress}");
                        }
                    }

                    // Daten für ComboBox3 - fg_3_KICK.csv, digi_3_KICK.csv, fg_3_MID.csv, digi_3_MID.csv
                    if (comboBox3.SelectedItem != null && frequency == comboBox3.SelectedItem.ToString().Trim())
                    {
                        var fgValuesKick3 = GetFgValues(fgCsvFilePath3_KICK, frequency);
                        var (closestValuesKick3, associatedValuesKick3) = GetClosestValues(digiCsvFilePath3_KICK, fgValuesKick3);

                        var fgValuesMid3 = GetFgValues(fgCsvFilePath3_MID, frequency);
                        var (closestValuesMid3, associatedValuesMid3) = GetClosestValues(digiCsvFilePath3_MID, fgValuesMid3);

                        // Senden der Werte über die serielle Schnittstelle
                        for (int i = 0; i < closestValuesKick3.Length; i++)
                        {
                            string chipSelect = GetChipSelectForResistance(chipSelectData, $"R_{i + 13}");
                            string adress = GetadressForResistance(chipSelectData, $"R_{i + 13}");
                            SendValuesToArduino(closestValuesKick3[i], associatedValuesKick3[i], chipSelect, adress);

                            // Gesendete Werte in den StringBuilder für das Log aufnehmen
                            sentData.AppendLine($"R_{i + 13}: {closestValuesKick3[i]} Ω Wert: {associatedValuesKick3[i]} ChipSelect: D{chipSelect} adress:{adress}");
                        }

                        for (int i = 0; i < closestValuesMid3.Length; i++)
                        {
                            string chipSelect = GetChipSelectForResistance(chipSelectData, $"R_{i + 17}");
                            string adress = GetadressForResistance(chipSelectData, $"R_{i + 17}");
                            SendValuesToArduino(closestValuesMid3[i], associatedValuesMid3[i], chipSelect, adress);

                            // Gesendete Werte in den StringBuilder für das Log aufnehmen
                            sentData.AppendLine($"R_{i + 17}: {closestValuesMid3[i]} Ω Wert: {associatedValuesMid3[i]} ChipSelect: D{chipSelect} adress:{adress}");
                        }
                    }

                    // Daten für ComboBox4 - fg_4_MID.csv, digi_4_MID.csv, fg_4_HI.csv, digi_4_HI.csv
                    if (comboBox4.SelectedItem != null && frequency == comboBox4.SelectedItem.ToString().Trim())
                    {
                        var fgValuesMid4 = GetFgValues(fgCsvFilePath4_MID, frequency);
                        var (closestValuesMid4, associatedValuesMid4) = GetClosestValues(digiCsvFilePath4_MID, fgValuesMid4);

                        var fgValuesHi4 = GetFgValues(fgCsvFilePath4_HI, frequency);
                        var (closestValuesHi4, associatedValuesHi4) = GetClosestValues(digiCsvFilePath4_HI, fgValuesHi4);

                        // Senden der Werte über die serielle Schnittstelle
                        for (int i = 0; i < closestValuesMid4.Length; i++)
                        {
                            string chipSelect = GetChipSelectForResistance(chipSelectData, $"R_{i + 21}");
                            string adress = GetadressForResistance(chipSelectData, $"R_{i + 21}");
                            SendValuesToArduino(closestValuesMid4[i], associatedValuesMid4[i], chipSelect, adress);

                            // Gesendete Werte in den StringBuilder für das Log aufnehmen
                            sentData.AppendLine($"R_{i + 21}: {closestValuesMid4[i]} Ω Wert:  {associatedValuesMid4[i]}  ChipSelect: D{chipSelect} adress:{adress}");
                        }

                        for (int i = 0; i < closestValuesHi4.Length; i++)
                        {
                            string chipSelect = GetChipSelectForResistance(chipSelectData, $"R_{i + 25}");
                            string adress = GetadressForResistance(chipSelectData, $"R_{i + 25}");
                            SendValuesToArduino(closestValuesHi4[i], associatedValuesHi4[i], chipSelect, adress);

                            // Gesendete Werte in den StringBuilder für das Log aufnehmen
                            sentData.AppendLine($"R_{i + 25}: {closestValuesHi4[i]} Ω Wert:  {associatedValuesHi4[i]}  ChipSelect: D{chipSelect} adress:{adress}");
                        }
                    }

                    // Daten für ComboBox5 - fg_5.csv, digi_5.csv
                    if (comboBox5.SelectedItem != null && frequency == comboBox5.SelectedItem.ToString().Trim())
                    {
                        var fgValues = GetFgValues(fgCsvFilePath5, frequency);
                        var (closestValues, associatedValues) = GetClosestValues(digiCsvFilePath5, fgValues);

                        // Senden der Werte über die serielle Schnittstelle
                        for (int i = 0; i < closestValues.Length; i++)
                        {
                            string chipSelect = GetChipSelectForResistance(chipSelectData, $"R_{i + 29}");
                            string adress = GetadressForResistance(chipSelectData, $"R_{i + 29}");
                            SendValuesToArduino(closestValues[i], associatedValues[i], chipSelect, adress);

                            // Gesendete Werte in den StringBuilder für das Log aufnehmen
                            sentData.AppendLine($"R_{i + 29}: {closestValues[i]} Ω Wert:  {associatedValues[i]}  ChipSelect: D{chipSelect} adress:{adress}");
                        }
                    }
                }

                // Alle gesendeten Daten in einer MessageBox anzeigen
                MessageBox.Show(sentData.ToString(), "Gesendete Daten");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}", "Fehler");
            }
        }

        // Methode zum Laden der Chip_Select.csv-Datei
        private List<ChipSelectEntry> LoadChipSelectData(string filePath)
        {
            var chipSelectData = new List<ChipSelectEntry>();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // Überspringen der Header-Zeile
            {
                var values = line.Split(';');
                if (values.Length >= 4)
                {
                    chipSelectData.Add(new ChipSelectEntry
                    {
                        ChipSelect = values[0].Trim(),
                        Widerstand = values[1].Trim(),
                        adress = values[2].Trim(),
                        IC = values[3].Trim()
                    });
                }
            }

            return chipSelectData;
        }

        // Methode zum Abrufen des ChipSelect-Werts für einen Widerstand
        private string GetChipSelectForResistance(List<ChipSelectEntry> chipSelectData, string resistance)
        {
            var entry = chipSelectData.FirstOrDefault(x => x.Widerstand == resistance);
            return entry?.ChipSelect ?? "Nicht gefunden";
        }
        // Methode zum Abrufen des adress-Werts für einen Widerstand
        private string GetadressForResistance(List<ChipSelectEntry> chipSelectData, string resistance)
        {
            var entry = chipSelectData.FirstOrDefault(x => x.Widerstand == resistance);
            return entry?.adress ?? "Nicht gefunden";
        }

        // Klasse zur Speicherung der ChipSelect-Daten
        public class ChipSelectEntry
        {
            public string ChipSelect { get; set; }
            public string Widerstand { get; set; }
            public string adress { get; set; }
            public string IC { get; set; }
        }


        // Methode zum Senden der Werte an den Arduino
        private void SendValuesToArduino(double closestValue, string associatedValue, string chipSelect, string adress)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string message = $"{chipSelect},{adress},{associatedValue}\n";
                    Debug.WriteLine($"{message}");
                    serialPort1.Write(message);
                }
                else
                {
                    MessageBox.Show("Die serielle Verbindung ist nicht geöffnet.", "Fehler");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Senden der Daten: {ex.Message}", "Fehler");
            }
        }


    }
}
