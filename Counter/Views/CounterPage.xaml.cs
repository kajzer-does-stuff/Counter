using Counter.Models;
using System.Diagnostics.Metrics;

namespace Counter.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class CounterPage : ContentPage
{
    public string ItemId
    {
        set { LoadCounter(value); }
    }
    public CounterPage()
	{
        InitializeComponent();

        string filename = $"{FileSystem.AppDataDirectory}/*.counter.txt";

        LoadCounter(filename);
	}
	public void AddOne_Clicked(object sender, EventArgs e)
	{
        if(BindingContext is Models.Counter counter)
        {
            counter.CurrentValue++;

           // CounterOperations.RefreshCounter(CurrentValDisplay, counter.CurrentValue);
            CounterOperations.SaveCounter(counter);
        }
    }
    public void RemoveOne_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Counter counter)
        {
            counter.CurrentValue--;
            //CounterOperations.RefreshCounter(CurrentValDisplay, counter.CurrentValue);
            CounterOperations.SaveCounter(counter);
        }
    }
    private void LoadCounter(string filename)
    {
        Models.Counter _counter = new Models.Counter();

        if (File.Exists(filename))
        {
            string savedData = File.ReadAllText(filename);

            _counter.FileName = filename;
            _counter.Name = savedData.Split("6^*!l")[0];
            _counter.StartingValue = int.Parse(savedData.Split("6^*!l")[1]);
            _counter.CurrentValue = int.Parse(savedData.Split("6^*!l")[2]);
            _counter.CounterID = int.Parse(savedData.Split("6^*!l")[3]);
        }

        StartingValDisplay.Text = _counter.StartingValue.ToString();

        //CounterOperations.RefreshCounter(CurrentValDisplay, _counter.CurrentValue);

        BindingContext = _counter;
    }
}