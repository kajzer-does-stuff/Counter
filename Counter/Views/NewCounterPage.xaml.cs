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
        //utworzenie nowego countera

        //nazwa i pocz¹tkowa wartoœc
        string counterName = "Counter";
        int counterStartingValue = 0;

        //walidacja
        //dzia³a w teorii
        //w praktyce - ???
        if(Regex.IsMatch(CounterStartingValue_Input.Text.ToString(), @"\d+"))
        {
            counterStartingValue = int.Parse(CounterStartingValue_Input.Text);
        }              
        if(Regex.IsMatch(CounterName_Input.Text.ToString(), @".+"))
        {
            counterName = CounterName_Input.Text.ToString();
        }

        //œcie¿ka do zapisu
        string savePath = $"{FileSystem.AppDataDirectory}/{counterName}_{Path.GetRandomFileName()}.counter.txt";

        //nowa instancja countera
        Models.Counter newCounter = new Models.Counter();
        newCounter.FileName = savePath;
        newCounter.Name = counterName;
        newCounter.StartingValue = counterStartingValue;
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