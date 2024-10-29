
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestionDeTareas.ViewModel;

public partial class MainViewModel : ObservableObject
{
    IConnectivity connectivity;
    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<string> items;
    [ObservableProperty]
    string text;
    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrEmpty(text))
        {
            return;
        }
        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("¡Vaya!", "Parece que no estás conectado a internet", "OK");
            return;
        }
        Items.Add(text);
        Text = string.Empty;
    }
    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }
    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }
    [RelayCommand]
    async Task AbrirLink()
    {
        var url = "https://principal.url.edu.gt/";
        if (Uri.TryCreate(url, UriKind.Absolute, out var uri))
        {
            await Launcher.Default.OpenAsync(uri);
        }
    }
}
