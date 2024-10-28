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
        //znajd� konkretnego countera, kt�ry w�a�nie zosta� klikni�ty
        Models.Counter counterInstance = (Models.Counter)(sender as Button).BindingContext;

        //dodaj +1 i zapisz now� wartos�
        CounterOperations.AddOne(counterInstance);
        CounterOperations.SaveCounter(counterInstance);

        //znajd� klikni�ty przycisk w drzewie element�w, jego rodzica, a potem jego etykiet� CurrentValDisplay (po nazwie) i od�wie� go
        object labelElement = (sender as Button).Parent.FindByName("CurrentValDisplay");
        CounterOperations.RefreshCounter((Label)labelElement, counterInstance.CurrentValue);        
    }
    private void RemoveOne_Clicked(object sender, EventArgs e)
    {
        //to samo co wy�ej - tym razem tylko odejmij -1
        Models.Counter counterInstance = (Models.Counter)(sender as Button).BindingContext;
        CounterOperations.RemoveOne(counterInstance);
        CounterOperations.SaveCounter(counterInstance);

        object labelElement = (sender as Button).Parent.FindByName("CurrentValDisplay");
        CounterOperations.RefreshCounter((Label)labelElement, counterInstance.CurrentValue);
    }
    private void Reset_Clicked(object sender, EventArgs e)
    {
        //reset warto�ci countera

        //podobna zasada co wy�ej
        Models.Counter counterInstance = (Models.Counter)(sender as Button).BindingContext;
        CounterOperations.ResetCounter(counterInstance);

        object labelElement = (sender as Button).Parent.FindByName("CurrentValDisplay");
        CounterOperations.RefreshCounter((Label)labelElement, counterInstance.CurrentValue);
    }
}