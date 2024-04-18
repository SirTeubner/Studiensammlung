using Studiensammlung.StudiensammlungCore.ViewModels;

namespace Studiensammlung.StudiensammlungApp;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
