namespace DummyApp;

public partial class Stats : ContentPage
{
	public Stats()
	{
        InitializeComponent();
        if (Preferences.Get("HasDoneStatisticsTutorial", false) == true && Preferences.Get("KeepHelpersEnabled", false) == false)
        {
            ScrollHelper.IsAnimationEnabled = false;
            ScrollHelper.IsVisible = false;
            ScrollHelper.IsEnabled = false;
        }
        OpenMenu.TranslateTo(-200, 0);
        if (Preferences.ContainsKey("TimesOpenedApp", ""))
        {
            var amount = Preferences.Get("TimesOpenedApp", 0);
            var newvar = Convert.ToInt32(amount) + 1;
            Preferences.Set("TimesOpenedApp", newvar);
        }
        else
        {
            Preferences.Set("TimesOpenedApp", 0);
        }
        var amount2 = Convert.ToString(Preferences.Get("TimesOpenedApp", 0));
        TimesOpenedApp.Text = "You have opened this app " + amount2 + " Time(s)!";
    }
    private const uint AnimationDuration = 800u;
    async void MenuButton_Tapped(object sender, EventArgs e)
    {
        //Reveal sidebar menu
        _ = MainContentGrid.TranslateTo(-this.Width * 0.9, this.Height * 0.9, AnimationDuration, Easing.CubicIn);
        await MainContentGrid.ScaleTo(0.1, AnimationDuration);
        _ = MainContentGrid.FadeTo(0.8, AnimationDuration);
        await Shell.Current.GoToAsync("//MainPage");
        _ = MainContentGrid.ScaleTo(1, 0);
        _ = MainContentGrid.FadeTo(1, 0);
        await MainContentGrid.TranslateTo(0, 0, 0, Easing.CubicIn);
    }

    async void GridArea_Tapped(object sender, EventArgs e)
    {
        //close the menu
        _ = MainContentGrid.ScaleTo(1, AnimationDuration);
        _ = MainContentGrid.FadeTo(1, AnimationDuration);
        await MainContentGrid.TranslateTo(0, 0, AnimationDuration, Easing.CubicIn);
    }

    private async void SwipeGestureRecognizer_Swiped_Close(object sender, SwipedEventArgs e)
    {
        Preferences.Set("HasDoneStatisticsTutorial", true);
        if (Preferences.Get("KeepHelpersEnabled", false) || Preferences.Get("HasDoneStatisticsTutorial", false) == false)
        {
            var c1 = ScrollHelper.TranslateTo(0, 0);
            var c2 = ScrollHelper.ScaleXTo(1);
            Task.WhenAll(c1, c2);
        }
        else
        {
            ScrollHelper.IsEnabled = false;
            ScrollHelper.IsVisible = false;
            ScrollHelper.IsAnimationEnabled = false;
        }
        var b1 = OpenMenu.TranslateTo(-200, 0);
        var b2 = StatsList.TranslateTo(0, 0);
        var b3 = ScrollDetector.TranslateTo(0, 0);
        await Task.WhenAll(b1, b2, b3);
    }

    private async void SwipeGestureRecognizer_Swiped_Open(object sender, SwipedEventArgs e)
    {
        if ((Preferences.Get("KeepHelpersEnabled", false) == false) || (Preferences.Get("HasDoneStatisticsTutorial", false) == false))
        {
            ScrollHelper.IsEnabled = false;
            ScrollHelper.IsVisible = false;
            ScrollHelper.IsAnimationEnabled = false;
        }
        else
        {
            var c1 = ScrollHelper.TranslateTo(130, 0);
            var c2 = ScrollHelper.ScaleXTo(-1);
            Task.WhenAll(c1, c2);
        }

        var a1 = OpenMenu.TranslateTo(0, 0);
        var a2 = StatsList.TranslateTo(200, 0);
        var a3 = ScrollDetector.TranslateTo(200, 0);
        await Task.WhenAll(a1, a2);
    }
}