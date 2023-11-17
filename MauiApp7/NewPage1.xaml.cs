using MauiApp7.ViewModels;

namespace MauiApp7;

public partial class NewPage1 : ContentPage
{
    public NewPage1()
    {
        BindingContext = new MainViewModel();
        InitializeComponent();
    }

}