using Counter.Models;
using System.Text.RegularExpressions;

namespace Counter.Views;

public partial class NewCounterPage : ContentPage
{
	public NewCounterPage()
	{
		InitializeComponent();
	}
	private async void AddCounter_Clicked(object sender, EventArgs e)
	{
        //nowa instancja countera
        Models.Counter newCounter = new Models.Counter();

        //walidacja
        //działa w teorii
        //w praktyce - ???
        string nameInput = CounterName_Input.Text.ToString();
        string numberInput = CounterStartingValue_Input.Text.ToString();

        if (Regex.IsMatch(nameInput, @".+"))
        {
            newCounter.Name = nameInput;
        }
        if (Regex.IsMatch(numberInput, @"\d+"))
        {
            newCounter.StartingValue = int.Parse(numberInput);
        }

        //ścieżka do zapisu
        string savePath = $"{FileSystem.AppDataDirectory}/{newCounter.Name}_{Path.GetRandomFileName()}.counter.txt";

        newCounter.FileName = savePath;
        newCounter.CurrentValue = newCounter.StartingValue;
        newCounter.CounterID = CounterOperations.nextCounterID;

        CounterOperations.nextCounterID++;

        //zapis danych countera do pliku
        CounterOperations.SaveCounter(newCounter);

        await Shell.Current.GoToAsync("..");
    }
    private async void Cancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
