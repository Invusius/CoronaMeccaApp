using CoronaMeccaApp.ViewModels;

namespace CoronaMeccaApp.Views;

public partial class CreateBoxPage : ContentPage
{
	public CreateBoxPage(CreateBoxViewModel createBoxViewModel)
	{
		InitializeComponent();

		BindingContext = createBoxViewModel;
	}
}