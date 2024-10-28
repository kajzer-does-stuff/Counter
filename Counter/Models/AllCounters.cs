using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics.Metrics;

namespace Counter.Models
{
    internal class AllCounters
    {
        public ObservableCollection<Counter> CounterCollection{ get; set; } = new ObservableCollection<Counter>();
        public AllCounters() => LoadAllCounters();

        public void LoadAllCounters()
        {
            //wyczyszczenie poprzedniego zbióru counterów
            CounterCollection.Clear();

            string savePath = FileSystem.AppDataDirectory;

            //lista wszystkich counterów ze ścieżki savePath, od razu wczytywanie odpowiednich danych
            IEnumerable<Counter> counterList = Directory
                .EnumerateFiles(savePath, "*.counter.txt")
                .Select(filename => new Counter()
                {
                    FileName = filename,
                    Name = File.ReadAllText(filename).Split("6^*!l")[0],
                    StartingValue = int.Parse(File.ReadAllText(filename).Split("6^*!l")[1]),
                    CurrentValue = int.Parse(File.ReadAllText(filename).Split("6^*!l")[2]),
                    CounterID = int.Parse(File.ReadAllText(filename).Split("6^*!l")[3]),
                })
                .OrderBy(counter => counter.CounterID);

            CounterOperations.nextCounterID = counterList.ToArray().Length;

            //dodanie znalezionych counterów do listy
            foreach (Counter _counter in counterList)
                CounterCollection.Add(_counter);
        }
    }
}
