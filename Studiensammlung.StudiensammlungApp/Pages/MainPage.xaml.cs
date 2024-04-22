using Studiensammlung.StudiensammlungCore.ViewModels;

namespace Studiensammlung.StudiensammlungApp.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
