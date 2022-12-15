namespace DummyApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        var Language = "English";
        var ChosenMainPage = "...";
        switch (Language)
        {
            case "Nederlands":
                {
                    ChosenMainPage = "https://www.r-go-tools.nl";
                    break;
                }
            case "Deutsch":
                {
                    ChosenMainPage = "https://www.r-go-tools.de";
                    break;
                }
            case "Français":
                {
                    ChosenMainPage = "https://www.r-go-tools.fr";
                    break;
                }
            default:
                {
                    ChosenMainPage = "https://www.r-go-tools.com";
                    break;
                }
        }
        WebsiteView.Source = ChosenMainPage;
    }

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		await DotnetBot.RotateTo(1000, 1000);
        await Shell.Current.GoToAsync("//Statistics");
		await DotnetBot.RotateTo(0, 1000);
	}

}