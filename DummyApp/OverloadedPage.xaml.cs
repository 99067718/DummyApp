namespace DummyApp;

public partial class OverloadedPage : ContentPage
{
	public OverloadedPage()
	{
		InitializeComponent();
	}
	protected async override void OnNavigatedTo(NavigatedToEventArgs args)
	{
        // This is the closest I can make it to an SQL database
		// that gets updated every time you re-open the page
		// without having to create an actual SQL database
        Items.Clear(); 
		await Task.Delay(100);
		_ = loadStuff();
	}
	private Task loadStuff()
	{
        for (var i = 0; i < 100; i++)
        {
			var time = DateTime.Now.ToString();
            Items.Add(new Label { Text = $"the time is now {time}"});
        }
		return null;
    }
}