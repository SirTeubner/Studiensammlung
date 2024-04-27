using Studiensammlung.StudiensammlungCore.ViewModels;

namespace Studiensammlung.StudiensammlungApp.Pages;

public partial class StatisticPage : ContentPage
{
	public StatisticPage(StatisticViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}