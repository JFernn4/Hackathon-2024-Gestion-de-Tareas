
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestionDeTareas.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Items = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> items;
    [ObservableProperty]
    string text;
    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrEmpty(text))
        {
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
}
