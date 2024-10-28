using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Models
{
    internal class CounterOperations
    {
        //różne funkcje dot. counterów
        public static int nextCounterID = 0;

        //dodawanie i odejmowanie do wartości
        public static void AddOne(Counter counter)
        {
            counter.CurrentValue++;
        }
        public static void RemoveOne(Counter counter)
        {
            counter.CurrentValue--;
        }

        //reset do wartości początkowej
        public static void ResetCounter(Counter counter)
        {
            counter.CurrentValue = counter.StartingValue;
        }

        //usunięcie countera
        public static void DeleteCounter(Counter counter)
        {
            counter.CurrentValue = counter.StartingValue;

            if (File.Exists(counter.FileName))
            {
                File.Delete(counter.FileName);
            }
        }

        //odświeżanie wyświetlanej wartości elementu w drzewie
        public static void RefreshCounter(Label refreshedDisplay, int newValue)
        {
            refreshedDisplay.Text = newValue.ToString();
        }

        //zapis countera do pliku
        public static void SaveCounter(Counter savedCounter)
        {
            //format [nazwa, wartość początkowa, wartość właściwa, ID]
            //6^*!l jako niby-losowy delimiter
            string saveData = $"{savedCounter.Name}6^*!l{savedCounter.StartingValue}6^*!l{savedCounter.CurrentValue}6^*!l{savedCounter.CounterID}";
            File.WriteAllText(savedCounter.FileName, saveData);
        }
    }
}
