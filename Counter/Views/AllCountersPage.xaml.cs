using Counter.Models;

namespace Counter.Views;

public partial class AllCountersPage : ContentPage
{
	public AllCountersPage()
	{
		InitializeComponent();

        BindingContext = new Models.AllCounters();
	}

    protected override void OnAppearing()
    {
        ((Models.AllCounters)BindingContext).LoadAllCounters();
    }

    private async void AddNewCounter_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NewCounterPage));
    }
    private void AddOne_Clicked(object sender, EventArgs e)
    {
        //znajdŸ konkretnego countera, który w³aœnie zosta³ klikniêty
        Models.Counter counterInstance = (Models.Counter)(sender as Button).BindingContext;

        //dodaj +1 i zapisz now¹ wartosæ
        CounterOperations.AddOne(counterInstance);
        CounterOperations.SaveCounter(counterInstance);

        //znajdŸ klikniêty przycisk w drzewie elementów, jego rodzica, a potem jego etykietê CurrentValDisplay (po nazwie) i odœwie¿ go
        object labelElement = (sender as Button).Parent.FindByName("CurrentValDisplay");
        CounterOperations.RefreshCounter((Label)labelElement, counterInstance.CurrentValue);        
    }
    private void RemoveOne_Clicked(object sender, EventArgs e)
    {
        //to samo co wy¿ej - tym razem tylko odejmij -1
        Models.Counter counterInstance = (Models.Counter)(sender as Button).BindingContext;
        CounterOperations.RemoveOne(counterInstance);
        CounterOperations.SaveCounter(counterInstance);

        object labelElement = (sender as Button).Parent.FindByName("CurrentValDisplay");
        CounterOperations.RefreshCounter((Label)labelElement, counterInstance.CurrentValue);
    }
    private void Reset_Clicked(object sender, EventArgs e)
    {
        //reset wartoœci countera

        //podobna zasada co wy¿ej
        Models.Counter counterInstance = (Models.Counter)(sender as Button).BindingContext;
        CounterOperations.ResetCounter(counterInstance);

        object labelElement = (sender as Button).Parent.FindByName("CurrentValDisplay");
        CounterOperations.RefreshCounter((Label)labelElement, counterInstance.CurrentValue);
    }
}