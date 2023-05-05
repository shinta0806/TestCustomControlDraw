using Microsoft.UI.Xaml.Controls;

using TestCustomControlDraw.ViewModels;

namespace TestCustomControlDraw.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
