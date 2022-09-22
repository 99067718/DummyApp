namespace DummyApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		await DotnetBot.RotateTo(1000, 1000);
        await Shell.Current.GoToAsync("//Statistics");
		await DotnetBot.RotateTo(0, 1000);
	}
}